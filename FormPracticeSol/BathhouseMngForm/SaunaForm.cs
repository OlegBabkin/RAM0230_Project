using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BathhouseMngForm
{
    public partial class SaunaForm : Form
    {
        // Power consumption variables
        private const int SAUNA_W = 8000;
        private const int RAD_W = 2000;
        private const int ROOM_LIGHT_W = 20;
        private const int BATHROOM_LIGHT_W = 20;
        private const int SAUNA_LIGHT_W = 20;
        private const int COFFEE_W = 400;
        private const int REFRIGERATOR_W = 110;
        private int sumConsumption = 0;
        private double powerConsumption = 0.0;

        // Time
        private const int TIME_INTERVAL = 1000;
        private int _seconds = 0;
        private int _minutes = 0;
        private int _hours = 0;
        private int _days = 0;
        public SaunaForm()
        {
            InitializeComponent();
        }

        private void SaunaForm_Load(object sender, EventArgs e)
        {
            timer.Interval = TIME_INTERVAL;
            timer.Start();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeSwitchPosition(CheckBox checkBox, int cons)
        {
            if (checkBox.Checked)
            {
                checkBox.ForeColor = Color.Green;
                checkBox.Text = "ON";
                sumConsumption += cons;
            }
            else
            {
                checkBox.ForeColor = Color.Red;
                checkBox.Text = "OFF";
                sumConsumption -= cons;
                if (sumConsumption < 0)
                {
                    sumConsumption = 0;
                }
            }
            circuitLoadTextBox.Text = sumConsumption.ToString() + " W";
        }

        private void updateAppTime()
        {
            timer.Interval = TIME_INTERVAL / (int) tSpeed.Value;
            switch (timeIncrem.Text)
            {
                case "sec":
                    _seconds++;
                    powerConsumption = powerConsumption + (double)sumConsumption / 3600.0 / 1000.0;
                    break;
                case "min":
                    powerConsumption = powerConsumption + (double)sumConsumption / 60.0 / 1000.0;
                    _minutes++;
                    break;
                default:
                    _seconds++;
                    break;
            }
           
            if (_seconds == 60)
            {
                _seconds = 0;
                _minutes++;
            }
            if (_minutes == 60)
            {
                _minutes = 0;
                _hours++;
            }
            if (_hours == 24)
            {
                _hours = 0;
                _days++;
            }
        }

        private void autumaticOnOffFunction(NumericUpDown onH, NumericUpDown onM, NumericUpDown offH, NumericUpDown offM, CheckBox cb)
        {
            if (onH.Value == _hours && onM.Value == _minutes && !cb.Checked)
            {
                cb.Checked = true;
            }
            if (offH.Value == _hours && offM.Value == _minutes && cb.Checked)
            {
                cb.Checked = false;
            }
        }

        private void refCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            changeSwitchPosition(refCheckBox, REFRIGERATOR_W);
        }

        private void radCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            changeSwitchPosition(radCheckBox, RAD_W);
        }

        private void cofCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            changeSwitchPosition(cofCheckBox, COFFEE_W);
        }

        private void saunaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            changeSwitchPosition(saunaCheckBox, SAUNA_W);
        }

        private void roomLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            changeSwitchPosition(roomLightCheckBox, ROOM_LIGHT_W);
        }

        private void bathroomLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            changeSwitchPosition(bathroomLightCheckBox, BATHROOM_LIGHT_W);
        }

        private void saunaLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            changeSwitchPosition(saunaLightCheckBox, SAUNA_LIGHT_W);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            updateAppTime();
            autumaticOnOffFunction(refAutOnH, refAutOnM, refAutOffH, refAutOffM, refCheckBox);
            autumaticOnOffFunction(radAutOnH, radAutOnM, radAutOffH, radAutOffM, radCheckBox);
            autumaticOnOffFunction(saunaAutOnH, saunaAutOnM, saunaAutOffH, saunaAutOffM, saunaCheckBox);
            autumaticOnOffFunction(cofAutOnH, cofAutOnM, cofAutOffH, cofAutOffM, cofCheckBox);
            timeTextBox.Text = _days+"  "+_hours+":"+_minutes+":"+_seconds.ToString();
            powerConsTextBox.Text = String.Format("{0:0.000} kW", powerConsumption);
        }
    }
}
