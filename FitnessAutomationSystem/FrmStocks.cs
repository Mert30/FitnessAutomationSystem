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
    public partial class FrmStocks : Form
    {
        public FrmStocks()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-H9055HU\SQLEXPRESS;Initial Catalog=ActiveGym;Integrated Security=True");

        private void dataShow()
        {
            listView1.Items.Clear();

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TBLProducts", sqlConnection);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem listView = new ListViewItem();

                listView.Text = reader["ProteinPowder"].ToString();
                listView.SubItems.Add(reader["Creatin"].ToString());
                listView.SubItems.Add(reader["BCAA"].ToString());
                listView.SubItems.Add(reader["Preworkout"].ToString());
                listView.SubItems.Add(reader["Vitamins"].ToString());
                listView.SubItems.Add(reader["Accessuar"].ToString());

                listView1.Items.Add(listView);
            }

            sqlConnection.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("INSERT INTO TBLProducts (ProteinPowder, Creatin, BCAA, Preworkout, Vitamins, Accessuar) VALUES (@P1, @P2, @P3, @P4, @P5, @P6)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@P1", TxtBoxProtein.Text);
            sqlCommand.Parameters.AddWithValue("@P2", TxtBoxCreatin.Text);
            sqlCommand.Parameters.AddWithValue("@P3", TxtBoxBCAA.Text);
            sqlCommand.Parameters.AddWithValue("@P4", TxtBoxPre.Text);
            sqlCommand.Parameters.AddWithValue("@P5", TxtBoxVit.Text);
            sqlCommand.Parameters.AddWithValue("@P6", TxtBoxAc.Text);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            dataShow();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            FrmHomePage frmHomePage = new FrmHomePage();
            frmHomePage.Show();
            this.Hide();    
        }
    }
}
