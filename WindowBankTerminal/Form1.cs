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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)// цикл проверки 
        {
                Data.machine = Data.bank.FindMachine(comboBox1.Text.Split(' ')[0]);
                if (Data.machine == -1) 
                {
                    MessageBox.Show("Банкомат не найден");
                }
                else 
                {
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.Show();
                }
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
