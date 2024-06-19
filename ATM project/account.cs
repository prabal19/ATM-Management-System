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
using System.Drawing.Text;

namespace ATM_project
{
    public partial class account : Form
    {
        public account()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\OneDrive\Documents\ATM_DB.mdf;Integrated Security=True;Connect Timeout=30");

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {


        }

        private void PhoneTb_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void Label14_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        
        
                int bal = 0;
                if (AccNametb.Text == "" || AccNumTb.Text == "" || FnameTb.Text == "" || PhoneTb.Text == "" 
                || Addresstb.Text == "" || occupationtb.Text == "" || Aadhartb.Text == "" || pintb.Text == "")
                {
                    MessageBox.Show("Missing information");
                }
                else
                {
                    try
                    {
                        Con.Open();
                        string query1 = "insert into AccountTb1 values('" + AccNumTb.Text + "','" + AccNametb.Text + "','" +
                        FnameTb.Text + "','" + Addresstb.Text + "','" + PhoneTb.Text + "','" + Aadhartb.Text + "','" + 
                        Educationcb.SelectedItem.ToString() + "','" + occupationtb.Text + "','" + dobdate.Value.Date + "'," +
                        "" + pintb.Text + "," + bal + ")";
                        SqlCommand cmd1 = new SqlCommand(query1, Con);
                        cmd1.ExecuteNonQuery();
                        string query2 = "insert into Clients values('"+AccNumTb.Text+"','"+AccNametb.Text+"','"+
                        pintb.Text+"')";
                        SqlCommand cmd2 = new SqlCommand(query2, Con);
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Account Created Successfully");
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

        private void account_Load(object sender, EventArgs e)
        {

        }
    }

}
