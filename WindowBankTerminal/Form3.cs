using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowBankTerminal
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pass = textBox1.Text;
            if (Data.bank._accounts[Data.card].Auth(pass)) 
            {
                this.Hide();
                Form4 f4 = new Form4();
                f4.Show();
            }
            else 
            {
                MessageBox.Show("Не правильный пин-код");
            }

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) {
                Application.Exit();
            }
        }
    }
}
