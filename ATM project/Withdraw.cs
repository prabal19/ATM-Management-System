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
    public partial class Withdraw : Form
    {
        public Withdraw()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        string Acc = login.AccNumber;
        int bal;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\OneDrive\Documents\ATM_DB.mdf;Integrated Security=True;Connect Timeout=30");
        private void addTransaction()
        {
            string TrType = "Withdraw";
            try
            {
                Con.Open();
                string query = "insert into TransactionTb1 values('" + Acc + "','" + TrType + "','" + wdamtTb1.Text + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        } 
        private void label4_Click(object sender, EventArgs e)
        {
            HOME hOME = new HOME();
            hOME.Show();
            this.Hide();
        }
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select bal from AccountTb1 where AccNum = '" + login.AccNumber + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelb1.Text = "Balance : Rs " + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
          
            Con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            getbalance();

        }
        int newbalance;
        private void button1_Click(object sender, EventArgs e)
        {
            if(wdamtTb1.Text== "")
            {
                MessageBox.Show("Missing Information");
            }
            else if(Convert.ToInt32(wdamtTb1.Text) <= 0)
            {
                MessageBox.Show("Enter the Valid Amout");

            }
            else if (Convert.ToInt32(wdamtTb1.Text)>bal)
            {
                MessageBox.Show("Insufficient Balance");

            }
            else
            {
                try
                {
                    newbalance = bal - Convert.ToInt32(wdamtTb1.Text);
                    try
                    {
                        Con.Open();
                        string query = "update AccountTb1 set bal =" + newbalance + " where AccNum='" + 
                            login.AccNumber + "'";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Succesful Withdrawal");
                        Con.Close();
                        addTransaction();
                        HOME home = new HOME();
                        home.Show();
                        this.Hide();

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);

                    }


                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }
    }
}
