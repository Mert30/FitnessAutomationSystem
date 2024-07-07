using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FitnessAutomationSystem
{
    public partial class FrmAddNewMember : Form
    {
        public FrmAddNewMember()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-H9055HU\SQLEXPRESS; Initial Catalog=ActiveGym; Integrated Security = True");

        private void BtnSave_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("INSERT INTO TBLNewMember VALUES (@P1, @P2, @P3, @P4, @P5, @P6, @P7)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@P1", TxtBoxName.Text);
            sqlCommand.Parameters.AddWithValue("@P2", TxtBoxSurname.Text);
            sqlCommand.Parameters.AddWithValue("@P3", comboBox1.Text);
            sqlCommand.Parameters.AddWithValue("@P4", mskTextBoxPhoneNumber.Text);
            sqlCommand.Parameters.AddWithValue("@P5", TxtBoxPrice.Text);
            sqlCommand.Parameters.AddWithValue("@P6", dtpTxtBoxEntry.Value.ToString("yyyy-MM-dd"));
            sqlCommand.Parameters.AddWithValue("@P7", dtpTxtBoxExit.Value.ToString("yyyy-MM-dd"));

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            MessageBox.Show("New member is added.");
        }

        private void dtpTxtBoxExit_ValueChanged(object sender, EventArgs e)
        {
            int initialMoney = 1000;

            DateTime smallTime = Convert.ToDateTime(dtpTxtBoxEntry.Value);
            DateTime bigTime = Convert.ToDateTime(dtpTxtBoxExit.Value);

            TimeSpan timeSpan = bigTime - smallTime;

            double price = initialMoney * timeSpan.TotalDays;

            TxtBoxPrice.Text = price.ToString();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            FrmProcess frmProcess = new FrmProcess();
            frmProcess.Show();
            this.Hide();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtBoxName.Clear();
            TxtBoxSurname.Clear();
            comboBox1.Text = "";
            mskTextBoxPhoneNumber.Clear();
            TxtBoxPrice.Clear();
            dtpTxtBoxEntry.Text = "";
            dtpTxtBoxExit.Text = "";
        }
    }
}
