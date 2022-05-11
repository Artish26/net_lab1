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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            float sum = 0;
            try {
                sum = float.Parse(textBox1.Text);
            }
            catch {
                MessageBox.Show("Ошибка, неправильно введена сумма");
                return;
            }
            Data.bank._machines[Data.machine].PutMoney(sum);
            Data.bank._accounts[Data.card].PutMoney(sum);
            this.Close();
        }
    }
}
