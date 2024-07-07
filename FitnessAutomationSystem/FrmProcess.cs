using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessAutomationSystem
{
    public partial class FrmProcess : Form
    {
        public FrmProcess()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-H9055HU\SQLEXPRESS;Initial Catalog=ActiveGym;Integrated Security=True");

        private void BtnAddNewMember_Click(object sender, EventArgs e)
        {
            FrmAddNewMember frmAddNewMember = new FrmAddNewMember();
            frmAddNewMember.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmHomePage frmHomePage = new FrmHomePage();
            frmHomePage.Show();
            this.Hide();
        }

        private void BtnPayment_Click(object sender, EventArgs e)
        {
            FrmBills frmPayment = new FrmBills();
            frmPayment.Show();
            this.Hide();
        }

        private void BtnUpdatePassword_Click(object sender, EventArgs e)
        {
            FrmUpdatePassword frmUpdatePassword = new FrmUpdatePassword();
            frmUpdatePassword.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmComment frmComment = new FrmComment();
            frmComment.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmIncomeAndExpense frmIncomeAndExpense = new FrmIncomeAndExpense();
            frmIncomeAndExpense.Show();
            this.Hide();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            FrmShowMember frmShowMember = new FrmShowMember();
            frmShowMember.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUpdateAndDeleteMember frmUpdateMember = new FrmUpdateAndDeleteMember();
            frmUpdateMember.Show();
            this.Hide();
        }

    }
}