using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.DAL.Model
{
    public class ClientRepository
    {
        //C:\Temp|MyData.db
        readonly string connectionString = "";
        public ClientRepository(string connectionString)
        {

            this.connectionString = connectionString;
        }
        public List<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();
            using (var db = new LiteDatabase(connectionString))
            {
                 clients = db.GetCollection<Client>("Client").FindAll().ToList();
            }
            return clients;
        }
        /// <summary>
        /// Метод который вощвращает есть ли клиент
        /// </summary>
        /// <param name="Mail"> Адресс электронной почты</param>
        /// <param name="Password"> Пароль </param>
        /// <returns></returns>
        public Client getClientData(string Mail,string Password)
        {
            List<Client> data = GetAllClients();

            //LINQ
            var client = data.FirstOrDefault(a => a.password == Password && a.email == Mail);
            return client;
        }
        public bool createClient(Client client)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var clients = db.GetCollection<Client>("Client");
                clients.Insert(client);
            }
            return true;
        }
    }
}
