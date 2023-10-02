using KKB.BLL.Model;
using System;
using System.Configuration;

namespace KKB.ConsoleApp
{
    public class MenuAction
    {
        readonly string path = "";

        public MenuAction()
        {
            path = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public bool Register()
        {
            ClientDTO client = new ClientDTO();

            Console.Write("Name: ");
            client.Name = Console.ReadLine();

            Console.Write("SurName: ");
            client.SurName = Console.ReadLine();

            Console.Write("Dob: ");
            client.Dob = DateTime.Parse(Console.ReadLine());

            Console.Write("Email: ");
            client.Email = Console.ReadLine();

            Console.Write("PhoneNumber: ");
            client.PhoneNumber = Console.ReadLine();

            Console.Write("Password: ");

            client.Password = Console.ReadLine();
            KKB.BLL.Model.ServiceClient service =
                new BLL.Model.ServiceClient(path);

            return service.RegsterClient(client);
        }

        public ClientDTO Auth()
        {
            Console.Write("email: ");
            string email = Console.ReadLine();

            Console.Write("password: ");
            string password = Console.ReadLine();

            KKB.BLL.Model.ServiceClient service =
                new BLL.Model.ServiceClient(path);

            try
            {
                return service.AuthorizeClient(email, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void UpdateClient(ClientDTO client)
        {

            Console.WriteLine("введите новый емайл");
            client.Email = Console.ReadLine();
            Console.WriteLine("введите новый телефон");
            client.PhoneNumber = Console.ReadLine();
            KKB.BLL.Model.ServiceClient srvc = new KKB.BLL.Model.ServiceClient(path);
            if (srvc.UpdateClient(client) != true)
            {
                Console.WriteLine("произошла ошибка");
            }
            else
            {
                Console.WriteLine("данные обновлены успешно");
            }
        }

        public void ShowAccount(int clientId)
        {
            ServiceAccount service = new ServiceAccount(path);

            var data = service.GetAllAccounts(clientId);
            Console.WriteLine(": {0}", data.message);

            foreach (AccountDTO acc in data.accounts)
            {
                Console.WriteLine("{0}. {1}\t{2} {3}",
                    acc.Id,
                    acc.IBAN,
                    acc.Balance,
                    acc.Currence);
            }
            Console.WriteLine("-------------------");
            Console.Write("Выберете счет: ");
            int selectedAccount = Int32.Parse(Console.ReadLine());

            var account = service.GetAccount(selectedAccount);
            if(account!=null)
            {
                Console.Clear();
                Console.WriteLine("{0}", account.IBAN);
                Console.WriteLine("от {0:dd.MM.yyyy}", account.CreateDate);
                Console.WriteLine("баланс {0}", account.Balance);

                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Пополнить");
                Console.WriteLine("2. Перевести");
                Console.WriteLine("3. Выписка");
            }
        }
    }
}
