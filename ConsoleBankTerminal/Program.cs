using ClassLib;

Bank bank = new Bank("PepeBank", "console");


int machine = -1;
int card = -1;

bool x = true;
while (x == true)
{
    Console.WriteLine("Выберите банкомат: 1 - Ул. Жуйко, 2 - Ул. Киевская.");
    string id = Console.ReadLine();
    machine = bank.FindMachine(id);
    if (machine == -1)
    {
        Console.WriteLine("Банкомат не найден, попробуйте еще раз");
    }
    else
    {
        Console.WriteLine("Банкомат найден");
        x = false;
    }
}

x = true;

while(x == true)
{
    Console.WriteLine("Введите номер карты (вида: 1111 1111 1111 1111)");
    string id = Console.ReadLine();
    card = bank.FindCard(id);
    if(card == -1)
    {
        Console.WriteLine("Карта не найдена, попробуйте еще раз");
    }
    else
    {
        Console.WriteLine("Карта найдена, введите пин-код(вида: 1111)");
        string pass = Console.ReadLine();
        if(bank._accounts[card].Auth(pass))
        {
            x = false;
        }

    }
}
x = true;
while(x == true)
{
    string n = "1-Проверить счет, 2-Снять деньги, 3-Положить деньги, 4-Перевести на другую карту, 0 - Выйти";
    float sum = 0;
    Console.WriteLine(n);
    n = Console.ReadLine();
    switch (n)
    {
        case "1":
            bank._accounts[card].CheckBallance();
            break;
        case "2":
            Console.WriteLine("Введите сумму");
            sum = 0;
            try
            {
                sum = float.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка, неправильно введена сумма");
                break;
            }
            if(bank._machines[machine].TakeMoney(sum))
            {
                if(!bank._accounts[card].TakeMoney(sum))
                {
                    bank._machines[machine].PutMoney(sum);
                    Console.WriteLine("В банкомате недостаточно денег");
                }
            }
            break;
        case "3":
            Console.WriteLine("Введити суму");
            sum = 0;
            try
            {
                sum = float.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка, неправильно введена сумма");
                break;
            }
            bank._machines[machine].PutMoney(sum);
            bank._accounts[card].PutMoney(sum);
            break;
        case "4":
            Console.WriteLine("Введите номер карты (вида: 1111 1111 1111 1111)");
            string id = Console.ReadLine();
            int card2 = bank.FindCard(id);
            if (card == -1)
            {
                Console.WriteLine("Карта не найдена, попробуйте еще раз");
            }
            else
            {
                Console.WriteLine("Введите сумму");
                sum = 0;
                try
                {
                    sum = float.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка, неправильно введена сумма");
                    break;
                }
                if (bank._machines[machine].TakeMoney(sum))
                {
                    if (!bank._accounts[card].TakeMoney(sum))
                    {
                        bank._machines[machine].PutMoney(sum);
                    }
                    else
                    {
                        bank._accounts[card2].PutMoneyTransfer(sum);
                    }
                }
            }
                break;
        case "0":
            x = false;
            break;
        default:
            Console.WriteLine("Ошибка, попробуйте еще раз");
            break;
    }
}

