using KKB.BLL.Model;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.ConsoleApp
{
    public static class Menu
    {
        public static void FirstMenu()
        {
            MenuAction menuAction = new MenuAction();

            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine("1. Авторизация");
            Console.WriteLine("2. Регистрация");
            Console.WriteLine("3. Выход");

            int choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.Clear();
                        ClientDTO clent = menuAction.Auth();

                        if (clent == null)
                        {
                            Console.WriteLine("Авторизация не прошла");
                        }
                        else
                        {
                            //Console.WriteLine("Авторизация успешна!");
                            SecondMenu(clent);
                        }
                        break;
                    }
                case 2:
                    Console.Clear();
                    menuAction.Register();
                    break;
                default: Environment.Exit(0);
                    break;
            }
        }
        public static void SecondMenu(ClientDTO client)
        {

            string path = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        
        MenuAction menuAction = new MenuAction();
            Console.Clear();
            Console.WriteLine("Добро пожаловать {0} {1}",client.Name,client.SurName);
            Console.WriteLine("Ваши счета: ...");
            Console.WriteLine("Хотите открыть новый счет ? да/нет: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "да":
                    {
                        Random rand = new Random();
                        AccountDTO account = new AccountDTO();
                        account.Balance = 0;
                        account.Currence = 398;
                        account.CreateDate = DateTime.Now;
                        account.ExpireDate = account.CreateDate.AddYears(15);
                        account.TypeCard = 1;
                        account.IBAN = "KZ" + rand.Next(1,100);
                        account.Clientid = client.Id;
                        ServiceAccount accs = new ServiceAccount(path);
                        var result = accs.createAccountClient(account);
                        if (!result.result)
                        {
                            Console.WriteLine("errorror");
                        }
                        break;
                    }
                case "нет":
                    {
                        Environment.Exit(0);
                        break;
                    }

            }
            menuAction.ShowAccount(client.Id);
        }
    }
}
//