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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //цикл с проверкой карты с библ, если нет, то опять ждать ввод
        {
            
            Data.card = Data.bank.FindCard(textBox1.Text);
            if (Data.card == -1) 
            {
                MessageBox.Show("Карта не найдена, попробуйте еще раз");
            }
            else 
            {
                this.Hide();
                Form3 f3 = new Form3();
                f3.Show();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing) 
            { 
                Application.Exit();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
