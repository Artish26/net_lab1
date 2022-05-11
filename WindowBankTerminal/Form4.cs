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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(); 
            f5.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data.bank._accounts[Data.card].CheckBallance();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(); 
            f6.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.ShowDialog();
        }
    }
}
