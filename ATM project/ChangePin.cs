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

namespace ATM_project
{
    public partial class ChangePin : Form
    {
        public ChangePin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            this.Hide();
            home.Show();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\Admin\OneDrive\Documents\ATM_DB.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            if (Pin1tb.Text == "" || Pin2tb.Text == "")
            {
                MessageBox.Show("Enter and Confirm the PIN");

            }
            else if (Pin2tb.Text != Pin1tb.Text)
            {
                MessageBox.Show("PIN does not match");
            }

            else
            {
                string Acc = login.AccNumber;
                try
                {
                    Con.Open();
                    string query = "update AccountTb1 set pin =" + Pin1tb.Text + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PIN succesfully Changed");
                    Con.Close();
                    login log = new login();
                    log.Show();
                    this.Hide();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }
    }
}
