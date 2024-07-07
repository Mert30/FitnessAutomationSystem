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
using System.Data.SqlClient;

namespace FitnessAutomationSystem
{
    public partial class FrmShowMember : Form
    {
        public FrmShowMember()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-H9055HU\SQLEXPRESS;Initial Catalog=ActiveGym;Integrated Security=True");
        
        private void ShowInformation()
        {
            listView1.Items.Clear();

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TBLNewMember", sqlConnection);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem listView = new ListViewItem();

                listView.Text = reader["ID"].ToString();
                listView.SubItems.Add(reader["Name"].ToString());
                listView.SubItems.Add(reader["Surname"].ToString());
                listView.SubItems.Add(reader["Gender"].ToString());
                listView.SubItems.Add(reader["PhoneNumber"].ToString());
                listView.SubItems.Add(reader["Price"].ToString());
                listView.SubItems.Add(reader["DateOfEntry"].ToString());
                listView.SubItems.Add(reader["DateOfExit"].ToString());

                listView1.Items.Add(listView);
            }

            sqlConnection.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            FrmProcess frmProcess = new FrmProcess();
            frmProcess.Show();
            this.Hide();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            ShowInformation();
        }
    }
}