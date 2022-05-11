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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            float sum = 0;
            try 
            {
                sum = float.Parse(textBox1.Text);
            }
            catch {
                MessageBox.Show("Ошибка, неправильно введена сумма");
                return;
            }
            if (Data.bank._machines[Data.machine].TakeMoney(sum)) {
                if (!Data.bank._accounts[Data.card].TakeMoney(sum)) 
                {
                    Data.bank._machines[Data.machine].PutMoney(sum);
                    MessageBox.Show("В бакномате недостаточно денег");
                }
                this.Close();
            }
        }
    }
}
