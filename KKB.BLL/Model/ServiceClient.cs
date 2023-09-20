﻿using KKB.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace KKB.BLL.Model
{
    public class ServiceClient
    {
        private ClientRepository repo = null;
        private readonly IMapper imapper;
        public ServiceClient(string connectionString)
        {
            repo = new ClientRepository(connectionString);
            imapper = BllSettings.Init().CreateMapper();
        }

        /// <summary>
        /// Регестрация
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool RegsterClient(ClientDTO  client)
        {
            try
            {
                repo.CreateClient(imapper.Map<Client>(client));
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
        public ClientDTO  AuthorizeClient(string Email, string Password)
        {
            ClientDTO  client = null;
            try
            {
                var _client = repo.GetClientData(Email, Password);
                client = imapper.Map<ClientDTO>(client);
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
        public bool UpdateClient(ClientDTO  client)
        {
            try
            {
                return repo.UpdateClient(imapper.Map<Client>(client));
            }
            catch
            {
                return false;
            }
        }


    }
}
