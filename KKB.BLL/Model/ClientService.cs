using KKB.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.Model
{
    public class ClientService
    {
        private ClientRepository repo;
        public ClientService(string connectionString)
        {
            repo = new ClientRepository(connectionString);
        }
        public bool registerClient(Client client)
        {
            //if (repo.getClientData(client.email,client.password) == null)
            //{
                
            //}
            repo.createClient(client);

            return true;
        }
        public Client authoriseClient(string mail, string password)
        {
            return repo.getClientData(mail,password);
        }
        public bool UpdateClient(Client client)
        {
            return true;
        }
    }
}