using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasStationMngForm
{
    public partial class StationForm : Form
    {
        // Prices
        private double petrol92Pr = 1.179;
        private double petrol95Pr = 1.269;
        private double dieselPr = 1.309;

        // Settings variables
        private const int INTERVAL = 1000;
        private int fillingSpeed = 1;
        private int flowRateLh = 3000;

        // Station variables
        private int _tickA = 0;
        private int _tickB = 0;
        private int _tickC = 0;
        private int _tickD = 0;

        private Boolean isFillingA = false;
        private Boolean isFillingB = false;
        private Boolean isFillingC = false;
        private Boolean isFillingD = false;

        private double totalPrA = 0.0;
        private double totalPrB = 0.0;
        private double totalPrC = 0.0;
        private double totalPrD = 0.0;

        public StationForm()
        {
            InitializeComponent();
        }

        private void StationForm_Load(object sender, EventArgs e)
        {
            timer.Interval = INTERVAL;
            timer.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            price92ben.Text = petrol92Pr.ToString();
            price95ben.Text = petrol95Pr.ToString();
            priceDiesel.Text = dieselPr.ToString();

            fillSpeedNum.Value = this.fillingSpeed;
            flowRateNum.Value = this.flowRateLh;

            if (!settingsGroupBox.Visible)
            {
                settingsGroupBox.Visible = true;
            }
        }

        private void settingsSaveBtn_Click_1(object sender, EventArgs e)
        {
            petrol92Pr = Double.Parse(price92ben.Text);
            petrol95Pr = Double.Parse(price95ben.Text);
            dieselPr = Double.Parse(priceDiesel.Text);

            this.fillingSpeed = (int)fillSpeedNum.Value;
            this.flowRateLh = (int)flowRateNum.Value;

            timer.Interval = INTERVAL / fillingSpeed;

            if (settingsGroupBox.Visible)
            {
                settingsGroupBox.Visible = false;
            }
        }

        private void settingsCancelBtn_Click(object sender, EventArgs e)
        {
            if (settingsGroupBox.Visible)
            {
                settingsGroupBox.Visible = false;
            }
        }

        private void stationCheck(PictureBox pb, ToolStripMenuItem mi)
        {
            pb.Image = global::GasStationMngForm.Properties.Resources.occupiedPetrolStation;
            mi.Checked = true;
            mi.Enabled = false;
        }

        private Boolean startStopTanking(Button btn, ComboBox fuelType,  ref int ttick)
        {
            Boolean isFilling = false;

            if (btn.Text.Equals("Start") && fuelType.Text.Length > 0)
            {
                ttick = 0;
                btn.Text = "Stop";
                isFilling = true;
            }
            else
            {
                btn.Text = "Start";
                isFilling = false;
            }
            return isFilling;
        }

        private double setPrice(String type)
        {
            double price = 0.0;
            switch (type)
            {
                case "92E":
                    price = this.petrol92Pr;
                    break;
                case "95E":
                    price = this.petrol95Pr;
                    break;
                case "DSL":
                    price = this.dieselPr;
                    break;
                default:
                    break;
            }
            return price;
        }

        private void stationAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stationCheck(pictureBox1, stationAToolStripMenuItem);
            setLitersA.Enabled = true;
            startStopA.Enabled = true;
            fuelTypeA.Enabled = true;
        }

        private void stationBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stationCheck(pictureBox2, stationBToolStripMenuItem);
            startStopB.Enabled = true;
            fuelTypeB.Enabled = true;
        }

        private void stationCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stationCheck(pictureBox3, stationCToolStripMenuItem);
            startStopC.Enabled = true;
            fuelTypeC.Enabled = true;
        }

        private void stationDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stationCheck(pictureBox4, stationDToolStripMenuItem);
            startStopD.Enabled = true;
            fuelTypeD.Enabled = true;
        }

        private void startStopA_Click(object sender, EventArgs e)
        {
            isFillingA = startStopTanking(startStopA, fuelTypeA, ref _tickA);
            if (isFillingA)
            {
                unitPriceA.Text = setPrice(fuelTypeA.Text).ToString();
            }
            else
            {
                totalPrA = Double.Parse(totalPriceA.Text);
                po_priceA.Text = totalPriceA.Text;
                po_volA.Text = litersA.Text;
            }
        }

        private void startStopTimer(bool isTanking, TextBox totalPrice, TextBox liters, ComboBox ft, ref int tick)
        {
            if (isTanking)
            {
                tick++;
                liters.Text = ((double)tick * (3600.0 / (double)flowRateLh)).ToString();
                totalPrice.Text = (tick * (3600.0 / (double)flowRateLh) * setPrice(ft.Text)).ToString();
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            startStopTimer(isFillingA, totalPriceA, litersA, fuelTypeA, ref _tickA);
            startStopTimer(isFillingB, totalPriceB, litersB, fuelTypeB, ref _tickB);
            startStopTimer(isFillingC, totalPriceC, litersC, fuelTypeC, ref _tickC);
            startStopTimer(isFillingD, totalPriceD, litersD, fuelTypeD, ref _tickD);
        }

        private void startStopB_Click(object sender, EventArgs e)
        {
            isFillingB = startStopTanking(startStopB, fuelTypeB, ref _tickB);
            if (isFillingB)
            {
                unitPriceB.Text = setPrice(fuelTypeB.Text).ToString();
            }
            else
            {
                totalPrB = Double.Parse(totalPriceB.Text);
                po_priceB.Text = totalPriceB.Text;
                po_volB.Text = litersB.Text;
            }
        }

        private void startStopC_Click(object sender, EventArgs e)
        {
            isFillingC = startStopTanking(startStopC, fuelTypeC, ref _tickC);
            if (isFillingC)
            {
                unitPriceC.Text = setPrice(fuelTypeC.Text).ToString();
            }
            else
            {
                totalPrC = Double.Parse(totalPriceC.Text);
                po_priceC.Text = totalPriceC.Text;
                po_volC.Text = litersC.Text;
            }
        }

        private void startStopD_Click(object sender, EventArgs e)
        {
            isFillingD = startStopTanking(startStopD, fuelTypeD, ref _tickD);
            if (isFillingD)
            {
                unitPriceD.Text = setPrice(fuelTypeD.Text).ToString();
            }
            else
            {
                totalPrD = Double.Parse(totalPriceD.Text);
                po_priceD.Text = totalPriceD.Text;
                po_volD.Text = litersD.Text;
            }
        }

        private void po_btnA_Click(object sender, EventArgs e)
        {
            if (po_priceA.Text.Equals(po_paymentA.Text))
            {
                pictureBox1.Image = global::GasStationMngForm.Properties.Resources.freePetrolStation;
                stationAToolStripMenuItem.Checked = false;
                stationAToolStripMenuItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("Wrong payment!");
            }
        }

        private void po_btnB_Click(object sender, EventArgs e)
        {
            if (po_priceB.Text.Equals(po_paymentB.Text))
            {
                pictureBox2.Image = global::GasStationMngForm.Properties.Resources.freePetrolStation;
                stationBToolStripMenuItem.Checked = false;
                stationBToolStripMenuItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("Wrong payment!");
            }
        }

        private void po_btnC_Click(object sender, EventArgs e)
        {
            if (po_priceC.Text.Equals(po_paymentC.Text))
            {
                pictureBox3.Image = global::GasStationMngForm.Properties.Resources.freePetrolStation;
                stationCToolStripMenuItem.Checked = false;
                stationCToolStripMenuItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("Wrong payment!");
            }
        }

        private void po_btnD_Click(object sender, EventArgs e)
        {
            if (po_priceD.Text.Equals(po_paymentD.Text))
            {
                pictureBox4.Image = global::GasStationMngForm.Properties.Resources.freePetrolStation;
                stationDToolStripMenuItem.Checked = false;
                stationDToolStripMenuItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("Wrong payment!");
            }
        }
    }
}
