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
    public partial class FrmUpdatePassword : Form
    {
        public FrmUpdatePassword()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-H9055HU\SQLEXPRESS;Initial Catalog=ActiveGym;Integrated Security=True");

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("DELETE FROM TBLLogScreen", sqlConnection);

            SqlCommand sqlCommand1 = new SqlCommand("INSERT INTO TBLLogScreen (UserName, Password) VALUES (@P1, @P2)", sqlConnection);

            sqlCommand1.Parameters.AddWithValue("@P1", TxtBoxUserName.Text);

            sqlCommand1.Parameters.AddWithValue("@P2", TxtBoxPassword.Text);

            sqlCommand.ExecuteNonQuery();

            sqlCommand1.ExecuteNonQuery();

            sqlConnection.Close();

            MessageBox.Show("UserName and Password updated.");
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            FrmProcess frmProcess = new FrmProcess();
            frmProcess.Show();
            this.Hide();
        }
    }
}
