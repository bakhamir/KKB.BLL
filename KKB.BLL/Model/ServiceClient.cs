using KKB.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KKB.DAL.Interfaces;

namespace KKB.BLL.Model
{
    public class ServiceClient
    {
        private readonly IRepository<Client> repo = null;
        private readonly IMapper iMapper;

        public ServiceClient(string connectionString)
        {
            repo = new repository<Client>(connectionString);
            iMapper = BLLSettings.Init().CreateMapper();
        }

        /// <summary>
        /// Регестрация
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool RegsterClient(ClientDTO client)
        {
            ReturnResult<Client> result = new ReturnResult<Client>();
            repo.Create(iMapper.Map<Client>(client));
            return result.IsError;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public ClientDTO AuthorizeClient(string Email, string Password)
        {

            try
            {
                ReturnResult<Client> result = new ReturnResult<Client>();
                //var _client = repo.GetClientData(Email, Password);
                //client = iMapper.Map<ClientDTO>(_client);
                var clients = repo.Get();
                if (result.IsError)
                {
                    throw new ArgumentException("ERROR");
                }
                var clientt = result.Datas.FirstOrDefault(f => f.Email == f.Email && f.Password == Password);
                return iMapper.Map<ClientDTO>(clientt);
            }
            catch
            {
                throw new ArgumentException("Воникла ошибка, попробуйте позже");
            }
        }

        /// <summary>
        /// Изменить данные клиента
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool UpdateClient(ClientDTO client)
        {
            ReturnResult<Client> result = new ReturnResult<Client>();
            result = repo.Update(iMapper.Map<Client>(client));

            return result.IsError;


        }
    }
}
