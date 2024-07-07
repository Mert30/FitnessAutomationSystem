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
    public partial class LogScreen : Form
    {
        public LogScreen()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-H9055HU\SQLEXPRESS;Initial Catalog=ActiveGym;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            FrmHomePage frmHomePage = new FrmHomePage();
            frmHomePage.Show();
            this.Hide();
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TBLLogScreen", sqlConnection);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string UserName = reader["UserName"].ToString();

                string password = reader["Password"].ToString();

                if ((TxtBoxUserName.Text == UserName) && (TxtBoxPassword.Text == password))
                {
                    FrmProcess frmProcess = new FrmProcess();
                    frmProcess.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("You entered wrong user name or password.");
                }
            }

            reader.Close();

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
