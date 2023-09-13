using KKB.DAL.Model;
using KKB.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            register();
        }
        static void auth()
        {
            Console.WriteLine("email: ");
            string email = Console.ReadLine();
            Console.WriteLine("password: ");
            string password = Console.ReadLine();
            string path = @"C:\\Temp\KKBData.db";
            KKB.BLL.Model.ClientService service = new BLL.Model.ClientService(path);
            service.authoriseClient(email, password);
        }
        static void register()
        {
            Client client = new Client();
            Console.WriteLine("name: ");
            client.name = Console.ReadLine();
            Console.WriteLine("surname: ");
            client.surname = Console.ReadLine();
            Console.WriteLine("date of birthday: ");
            client.created = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("mail");
            client.email = Console.ReadLine();
            Console.WriteLine("password: ");
            client.password = Console.ReadLine();
            Console.WriteLine("number");
            client.number = Console.ReadLine();
            string path = @"C:\\Temp\KKBData.db";
            KKB.BLL.Model.ClientService service = new BLL.Model.ClientService(path);
            service.registerClient(client);
            Console.WriteLine("Регистрация прошла успешно!");
        }

    }
}
