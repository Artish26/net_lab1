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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string id = textBox1.Text;
            int card2 = Data.bank.FindCard(id);
            if (card2 == -1) {
                MessageBox.Show("Карта не найдена");
            }
            else {
                float sum = 0;
                try {
                    sum = float.Parse(textBox2.Text);
                }
                catch {
                    MessageBox.Show("Сума введена не праввильно");
                    return;
                }
                if (Data.bank._machines[Data.machine].TakeMoney(sum)) {
                    if (!Data.bank._accounts[Data.card].TakeMoney(sum)) {
                        Data.bank._machines[Data.machine].PutMoney(sum);
                    }
                    else {
                        Data.bank._accounts[card2].PutMoneyTransfer(sum);
                    }
                }
            }
            this.Close();
        }
    }
}
