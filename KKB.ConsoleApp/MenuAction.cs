using KKB.BLL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.ConsoleApp
{
    public class MenuAction
    {
        readonly string path = "";

        public MenuAction()
        {
            path = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Register()
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

            service.RegsterClient(client);
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
        //public Account GetAccount(ClientDTO client)
        //{
        //    ClientDTO clent = new ClientDTO();
        //    Account account = new Account();
        //    clent.Account.Append(account);
        //    account.Balance = 123;
        //    return null;
        //}
    }
}
