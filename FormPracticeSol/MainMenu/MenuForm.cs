using System;
using System.Windows.Forms;
using BathhouseMngForm;
using GasStationMngForm;

namespace MainMenu
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void toGasStationPr_btn_Click(object sender, EventArgs e)
        {
            StationForm stationForm = new StationForm();
            stationForm.Show();
        }

        private void toSaunaPr_btn_Click(object sender, EventArgs e)
        {
            SaunaForm sForm = new SaunaForm();
            sForm.Show();
        }
    }
}
