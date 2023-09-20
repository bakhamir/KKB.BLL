using KKB.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.Model
{
    public class ServiceClient
    {
        private ClientRepository repo = null;

        public ServiceClient(string connectionString)
        {
            repo = new ClientRepository(connectionString);
        }

        /// <summary>
        /// Регестрация
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool RegsterClient(Client client)
        {
            try
            {
                repo.CreateClient(client);
            }
            catch
            {

                throw new ArgumentException("ВОЗНИКЛА ОШИБКА ПОВТОРИТЕ ПОЗЖЕ");
            }
            return true;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Client AuthorizeClient(string Email, string Password)
        {
            Client client = null;
            try
            {
                client = repo.GetClientData(Email, Password);
            }
            catch
            {
                throw new ArgumentException("Воникла ошибка, попробуйте позже");
            }          

            return client;
        }

        /// <summary>
        /// Изменить данные клиента
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool UpdateClient(Client client)
        {
            try
            {
                return repo.UpdateClient(client);
            }
            catch
            {
                return false;
            }
        }


    }
}
