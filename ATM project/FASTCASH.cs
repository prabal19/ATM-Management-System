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
    public partial class FASTCASH : Form
    {
        public FASTCASH()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\OneDrive\Documents\ATM_DB.mdf;Integrated Security=True;Connect Timeout=30");
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        string Acc= login.AccNumber;
        private void addTransaction1()
        {
            string TrType = "Withdraw";
            try
            {
                Con.Open();
                string query = "insert into TransactionTb1 values('" + Acc + "','" + TrType + "','" + 100 + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }
        private void addTransaction2()
        {
            string TrType = "Withdraw";
            try
            {
                Con.Open();
                string query = "insert into TransactionTb1 values('" + Acc + "','" + TrType + "','" + 500 + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }
        private void addTransaction3()
        {
            string TrType = "Withdraw";
            try
            {
                Con.Open();
                string query = "insert into TransactionTb1 values('" + Acc + "','" + TrType + "','" + 1000 + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }
        private void addTransaction4()
        {
            string TrType = "Withdraw";
            try
            {
                Con.Open();
                string query = "insert into TransactionTb1 values('" + Acc + "','" + TrType + "','" + 2000 + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }
        private void addTransaction5()
        {
            string TrType = "Withdraw";
            try
            {
                Con.Open();
                string query = "insert into TransactionTb1 values('" + Acc + "','" + TrType + "','" + 5000 + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }
        private void addTransaction6()
        {
            string TrType = "Withdraw";
            try
            {
                Con.Open();
                string query = "insert into TransactionTb1 values('" + Acc + "','" + TrType + "','" + 10000 + "','" + DateTime.Now.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HOME hOME = new HOME(); 
            hOME.Show();
            this.Hide();
        }
        int bal;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select bal from AccountTb1 where AccNum = '" + login.AccNumber + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balTb1.Text = "Balance : Rs " + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }

        private void FASTCASH_Load(object sender, EventArgs e)
        {
            getbalance();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (bal < 1000)
            {
                MessageBox.Show("Insufficient Balance");

            }
            else
            {
                int newbalance = bal - 1000;
                try
                {
                    Con.Open();
                    string query = "update AccountTb1 set bal =" + newbalance + " where AccNum='" + login.AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Money has been succesfully withdrawn");
                    Con.Close();
                    addTransaction3();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(bal < 100)
            {
                MessageBox.Show("Insufficient Balance");

            }
            else
            {
                int newbalance = bal - 100;
                try
                {
                    Con.Open();
                    string query = "update AccountTb1 set bal =" + newbalance + " where AccNum='" + login.AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Money has been succesfully withdrawn");
                    Con.Close();
                    addTransaction1();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bal < 500)
            {
                MessageBox.Show("Insufficient Balance");

            }
            else
            {
                int newbalance = bal - 500;
                try
                {
                    Con.Open();
                    string query = "update AccountTb1 set bal =" + newbalance + " where AccNum='" + login.AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Money has been succesfully withdrawn");
                    Con.Close();
                    addTransaction2();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (bal < 2000)
            {
                MessageBox.Show("Insufficient Balance");

            }
            else
            {
                int newbalance = bal - 2000;
                try
                {
                    Con.Open();
                    string query = "update AccountTb1 set bal =" + newbalance + " where AccNum='" + login.AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Money has been succesfully withdrawn");
                    Con.Close();
                    addTransaction4();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (bal < 5000)
            {
                MessageBox.Show("Insufficient Balance");

            }
            else
            {
                int newbalance = bal - 5000;
                try
                {
                    Con.Open();
                    string query = "update AccountTb1 set bal =" + newbalance + " where AccNum='" + login.AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Money has been succesfully withdrawn");
                    Con.Close();
                    addTransaction5();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (bal < 10000)
            {
                MessageBox.Show("Insufficient Balance");

            }
            else
            {
                int newbalance = bal - 10000;
                try
                {
                    Con.Open();
                    string query = "update AccountTb1 set bal =" + newbalance + " where AccNum='" + login.AccNumber + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Money has been succesfully withdrawn");
                    Con.Close();
                    addTransaction6();
                    HOME home = new HOME();
                    home.Show();
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
