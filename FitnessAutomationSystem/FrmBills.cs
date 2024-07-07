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
    public partial class FrmBills : Form
    {
        public FrmBills()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-H9055HU\SQLEXPRESS;Initial Catalog=ActiveGym;Integrated Security=True");

        private void dataShow()
        {
            listView1.Items.Clear();

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TBLBills", sqlConnection);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem listView = new ListViewItem();

                listView.Text = reader["Electric"].ToString();
                listView.SubItems.Add(reader["Internet"].ToString());
                listView.SubItems.Add(reader["Water"].ToString());
                listView.SubItems.Add(reader["NaturalGas"].ToString());

                listView1.Items.Add(listView);
            }

            sqlConnection.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("INSERT INTO TBLBills (Electric, Internet, Water, NaturalGas) VALUES (@P1, @P2, @P3, @P4)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@P1", TxtBoxElectric.Text);
            sqlCommand.Parameters.AddWithValue("@P2", TxtBoxInternet.Text);
            sqlCommand.Parameters.AddWithValue("@P3", TxtBoxWater.Text);
            sqlCommand.Parameters.AddWithValue("@P4", TxtBoxNaturalGas.Text);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            dataShow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmProcess frmProcess = new FrmProcess();
            frmProcess.Show();
            this.Hide();
        }
    }
}
