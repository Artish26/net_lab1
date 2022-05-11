using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClassLib
{
    public delegate void AccountHandler(object sender, AccountArgs e);
    public class AccountArgs : EventArgs
    {
        public string Message;
        public AccountArgs(string mes)
        {
            Message = mes;
        }
    }

    public class Messages
    {
        public static void ShowMessageConsole(object sender, AccountArgs e)
        {
            Console.WriteLine(e.Message);
        }
        public static void ShowMessageWindow(object sender, AccountArgs e)
        {
            MessageBox.Show(e.Message);
        }
    }

    


    public class Account
    {
        private bool _auth = false;
        private string _password = "";
        private float _sum = 0;
        private string _username = "";
        private string _card = "";
        event AccountHandler Notify;

        public Account(string password, float sum, string username, string card, string type)
        {
            _password = password;
            _sum = sum;
            _username = username;
            _card = card;
            if(type == "console")
            {
                Notify += Messages.ShowMessageConsole;
            }
            else
            {
                Notify += Messages.ShowMessageWindow;
            }
        }
        public bool Auth(string password)
        {
            if (_password == password)
            {
                _auth = true;
                Notify.Invoke(this, new AccountArgs("Авторизация выполнена"));
                return true;
            }
            else
            {
                Notify.Invoke(this, new AccountArgs("Авторизация не выполнена, попробуйте еще раз"));
                return false;
            }
        }
        public void CheckBallance()
        {
            Notify.Invoke(this, new AccountArgs($"Баланс: {_sum}"));
        }
        public void PutMoney(float sum)
        {
            _sum += sum;
            Notify.Invoke(this, new AccountArgs($"Ваш счет: {_sum}"));
        }
        public bool TakeMoney(float sum)
        {
            if(_sum >= sum)
            {
                _sum -= sum;
                Notify.Invoke(this, new AccountArgs($"Ваш счет: {_sum}"));
                return true;
            }
            else
            {
                Notify.Invoke(this, new AccountArgs("Недостаточно денег"));
                return false;
            }
        }
        public void TransferMoney(float sum, Account secCard)
        {
            if(_sum >= sum)
            {
                secCard.PutMoney(sum);
                _sum -= sum;
                Notify.Invoke(this, new AccountArgs("Операция выполнена успешно"));
            }
            else
            {
                Notify.Invoke(this, new AccountArgs("Недостаточно денег"));
            }
        }
        public string GetNumber()
        {
            return string.Join("", _card.Split(' '));
        }
        public void PutMoneyTransfer(float sum)
        {
            _sum += sum;
            Notify.Invoke(this, new AccountArgs($"Сумма {sum} была переслана"));
        }
    };

    public class AutomatedTellerMachine
    {
        float _sum = 0;
        string _id = "";
        string _location = "";
        delegate void AccountHandler(object sender, AccountArgs e);
        event AccountHandler Notify;

        public AutomatedTellerMachine(string id, string location, float sum, string type)
        {
            _id = id;
            _location = location;
            _sum = sum;
            if (type == "console")
            {
                Notify += Messages.ShowMessageConsole;
            }
            else
            {
                Notify += Messages.ShowMessageWindow;
            }
        }
        public void PutMoney(float sum)
        {
            _sum += sum;
        }
        public bool TakeMoney(float sum)
        {
            if (_sum >= sum)
            {
                _sum -= sum;
                return true;
            }
            else
            {
                Notify.Invoke(this, new AccountArgs("Недостаточно денег в банкомате"));
                return false;
            }
        }
        public string GetId()
        {
            return _id;
        }
    };

    public class Bank
    {
        string _name = "";
        public List<AutomatedTellerMachine> _machines = new List<AutomatedTellerMachine>();
        public List<Account> _accounts = new List<Account>();
        public Bank(string name, string type)
        {
            _name = name;
            _machines.Add(new AutomatedTellerMachine("1", "St. Zhuyka 2", 1000, type));
            _machines.Add(new AutomatedTellerMachine("2", "St. Kiyvska 32", 2000, type));

            _accounts.Add(new Account("1111", 100, "Artem", "1234 1234 1234 1234", type));
            _accounts.Add(new Account("2222", 200, "Petro", "2345 5412 1673 6323", type));
        }
        public int FindCard(string id)
        {
            for (int i = 0;i < _accounts.Count; i++)
            {
                if (_accounts[i].GetNumber().Equals(String.Join("", id.Split(' '))))
                {
                    return i;
                }
            }
            return -1;
        }
        public int FindMachine(string id)
        {
            for (int i = 0; i < _machines.Count; i++)
            {
                if (_machines[i].GetId().Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    };
}
