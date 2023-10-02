using System;
using System.Configuration;
using KKB.BLL.Model;

namespace KKB.ConsoleApp
{
    public static class Menu
    {
        static string path = "";

        static Menu()
        {
            path = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

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
                            SecondMenu(clent);
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("- Регистрация пользователя -");
                        if (menuAction.Register())
                        {
                            Console.Clear();
                            FirstMenu();
                        }
                        break;
                    }
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void SecondMenu(ClientDTO client)
        {
            MenuAction menuAction = new MenuAction();
            Console.Clear();

            Console.WriteLine("Добро пожаловать {0}", client.ShortName);

            Console.WriteLine("Ваши счета: ...");
            menuAction.ShowAccount(client.Id);
            Console.WriteLine("");

            Console.WriteLine("---------------------||----------------");
            Console.Write("Хотите открыть новый счет да/нет: ");
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
                        account.IBAN = "KZ" + rand.Next(100, 999);
                        account.ClientId = client.Id;

                        ServiceAccount service = new ServiceAccount(path);
                        var result = service.CreateAccountClient(account);

                        if (result.result)
                            Console.WriteLine(result.message);
                        else
                            SecondMenu(client);
                        break;
                    }
            }
        }
    }
}
