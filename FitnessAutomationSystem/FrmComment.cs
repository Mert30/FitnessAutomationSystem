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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FitnessAutomationSystem
{
    public partial class FrmComment : Form
    {
        public FrmComment()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-H9055HU\SQLEXPRESS;Initial Catalog=ActiveGym;Integrated Security=True");

        private void dataShow()
        {
            listView1.Items.Clear();

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TBLComment", sqlConnection);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem listView = new ListViewItem();

                listView.Text = reader["ID"].ToString();
                listView.SubItems.Add(reader["Name"].ToString());
                listView.SubItems.Add(reader["Surname"].ToString());
                listView.SubItems.Add(reader["Comment"].ToString());

                listView1.Items.Add(listView);
            }

            sqlConnection.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("INSERT INTO TBLComment (Name, Surname, Comment) VALUES (@P1, @P2, @P3)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@P1", TxtBoxName.Text);
            sqlCommand.Parameters.AddWithValue("@P2", TxtBoxSurname.Text);
            sqlCommand.Parameters.AddWithValue("@P3", rTxtBoxComment.Text);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            dataShow();
        }

        private void FrmComment_Load(object sender, EventArgs e)
        {
            dataShow();
        }

        int id;

        private void listView1_Click(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            TxtBoxName.Text = listView1.SelectedItems[0].SubItems[1].Text;
            TxtBoxSurname.Text = listView1.SelectedItems[0].SubItems[2].Text;
            rTxtBoxComment.Text = listView1.SelectedItems[0].SubItems[3].Text;
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
            rTxtBoxComment.Clear();
        }
    }
}