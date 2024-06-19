using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_project
{
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }
        string Acc=login.AccNumber;
        private void label14_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\Admin\OneDrive\Documents\ATM_DB.mdf;Integrated Security=True;Connect Timeout=30");
        private void addTransaction()
        {
            string TrType = "Deposit";
            try
            {
                Con.Open();
                string query = "insert into TransactionTb1 values('" +Acc+ "','" +TrType+ "'," +
                    "'" +DepoAmtTb.Text+ "','" +DateTime.Now.ToString()+ "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(DepoAmtTb.Text=="" || Convert.ToInt32(DepoAmtTb.Text) <= 0)
            {
                MessageBox.Show("Enter the amount to deposit");

            }
            else
            {
                string Acc = login.AccNumber;
                newbalance = oldbalance + Convert.ToInt32(DepoAmtTb.Text);
                try
                {
                    Con.Open();
                    string query = "update AccountTb1 set bal =" + newbalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Deposit has been succesfully made");
                    Con.Close();
                    addTransaction();
                    HOME home = new HOME();
                    home.Show();
                    this.Hide();

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
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
        int oldbalance,newbalance;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select bal from AccountTb1 where AccNum " +
                "= '" +login.AccNumber+ "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldbalance = Convert.ToInt32( dt.Rows[0][0].ToString());
            Con.Close();
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            getbalance();

        }
    }
}
