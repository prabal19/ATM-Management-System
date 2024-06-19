using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_project
{
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BALANCE bal = new BALANCE();
            this.Hide();
            bal.Show();
        }
        public static string AccNumber;
        private void HOME_Load(object sender, EventArgs e)
        {
            AccNumtb1.Text = "Account Number: " + login.AccNumber;
            AccNumber = login.AccNumber;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Deposit deposit = new Deposit();
            this.Hide();
            deposit.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Withdraw withdraw = new Withdraw();
            this.Hide();
            withdraw.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FASTCASH fASTCASH = new FASTCASH();
            this.Hide();
            fASTCASH.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MiniStatement miniStatement = new MiniStatement();
            this.Hide(); miniStatement.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangePin changePin = new ChangePin();
            this.Hide(); changePin.Show();
        }

        private void AccNumtb1_Click(object sender, EventArgs e)
        {

        }
    }
}
