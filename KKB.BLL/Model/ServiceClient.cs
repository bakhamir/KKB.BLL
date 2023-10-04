using KKB.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KKB.DAL;
using KKB.DAL.Interfaces;

namespace KKB.BLL.Model
{
    public class ServiceClient : service<Client>
    {

        public ServiceClient(string connectionString) : base(connectionString)
        {

        }

        /// <summary>
        /// Регестрация
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool RegsterClient(ClientDTO client)
        {
            ReturnResult<Client> result = new ReturnResult<Client>();

            result = repo.Create(iMapper.Map<Client>(client));

            return !result.IsError;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public IClientDTOShort AuthorizeClient(string Email, string Password)
        {
            ReturnResult<Client> result = new ReturnResult<Client>();

            //вернул всех клиентов
            result = repo.Get();
            if (result.IsError)
                throw new ArgumentException("Воникла ошибка, попробуйте позже");

            var client = result.Datas
                .FirstOrDefault(f => f.Email == Email
                                  && f.Password == Password);

            return iMapper.Map<ClientDTO>(client);
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
