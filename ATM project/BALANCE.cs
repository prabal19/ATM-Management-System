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
    public partial class BALANCE : Form
    {
        public BALANCE()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            this.Hide();
            home.Show();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\Admin\OneDrive\Documents\ATM_DB.mdf;Integrated Security=True;Connect Timeout=30");
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select bal from AccountTb1 where " +
                "AccNum = '"+AccNumbertb1.Text+"'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancetb1.Text ="Rs "+ dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void BALANCE_Load(object sender, EventArgs e)
        {
            AccNumbertb1.Text = HOME.AccNumber;
            getbalance();
        }
    }
}
