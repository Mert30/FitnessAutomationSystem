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
    public partial class FrmUpdateAndDeleteMember : Form
    {
        public FrmUpdateAndDeleteMember()
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

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand =
                new SqlCommand("UPDATE TBLNewMember SET Name = @P1, Surname = @P2, Gender = @P3, PhoneNumber = @P4, Price = @P5, DateOfEntry = @P6, DateOfExit  = @P7 WHERE ID = @P8", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@P1", TxtBoxName.Text);
            sqlCommand.Parameters.AddWithValue("@P2", TxtBoxSurname.Text);
            sqlCommand.Parameters.AddWithValue("@P3", comboBox1.Text);
            sqlCommand.Parameters.AddWithValue("@P4", mskTextBoxPhoneNumber.Text);
            sqlCommand.Parameters.AddWithValue("@P5", TxtBoxPrice.Text);
            sqlCommand.Parameters.AddWithValue("@P6", dtpTxtBoxEntry.Value.ToString("yyyy-MM-dd"));
            sqlCommand.Parameters.AddWithValue("@P7", dtpTxtBoxExit.Value.ToString("yyyy-MM-dd"));
            sqlCommand.Parameters.AddWithValue("@P8", id);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            ShowInformation();

            MessageBox.Show("Data updated.");
        }

        int id;

        private void listView1_Click(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            TxtBoxName.Text = listView1.SelectedItems[0].SubItems[1].Text;
            TxtBoxSurname.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            mskTextBoxPhoneNumber.Text = listView1.SelectedItems[0].SubItems[4].Text;
            TxtBoxPrice.Text = listView1.SelectedItems[0].SubItems[5].Text;
            dtpTxtBoxEntry.Text = listView1.SelectedItems[0].SubItems[6].Text;
            dtpTxtBoxExit.Text = listView1.SelectedItems[0].SubItems[7].Text;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("DELETE FROM TBLNewMember WHERE Name = @P1", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@P1", TxtBoxName.Text);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            ShowInformation();

            MessageBox.Show("Data deleted.");
        }

        private void FrmUpdateAndDeleteMember_Load(object sender, EventArgs e)
        {
            ShowInformation();
        }
    }
}
