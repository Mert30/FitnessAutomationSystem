using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessAutomationSystem
{
    public partial class FrmHomePage : Form
    {
        public FrmHomePage()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAboutUs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ACTIVE GYM established in 1900 by Gökmen and Dilaver Brothers.");
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            FrmProcess frmProcess = new FrmProcess();
            frmProcess.Show();
            this.Hide();
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
           LogScreen logScreen = new LogScreen();
           logScreen.Show();
           this.Hide();
        }

        private void BtnStocks_Click(object sender, EventArgs e)
        {
            FrmStocks frmStocks = new FrmStocks();
            frmStocks.Show();
            this.Hide();
        }

        private void BtnRadio_Click(object sender, EventArgs e)
        {
            FrmRadio frmRadio = new FrmRadio();
            frmRadio.Show();
            this.Hide();
        }
    }
}
