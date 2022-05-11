using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLib;

namespace WindowBankTerminal
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        
    }

    class Data
    {
        public static Bank bank = new Bank("PepeBank", "window");
        public static int machine = -1;
        public static int card = -1;
    }
}
