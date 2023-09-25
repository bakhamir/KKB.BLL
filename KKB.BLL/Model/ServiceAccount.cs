using AutoMapper;
using KKB.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.Model
{
    public class ServiceAccount
    {
        private AccountRepository repo = null;
        private readonly IMapper imapper;
        public ServiceAccount(string connectionString)
        {
            repo = new AccountRepository(connectionString);
            imapper = BllSettings.Init().CreateMapper();
        }
        public (string message , List<AccountDTO> accounts) GetAccounts(int clientid)
        {
            var result = repo.GetAccounts();
            return (result.Exception.Message,imapper.Map<List<AccountDTO>>(result.Accounts));
            //if (result.IsError)
            //{

            //    return (result.Exception.Message,null);
            //}
            //else
            //{
            //    return ("",imapper.Map<List<AccountDTO>>(result.Accounts));
            //}
        }
        public (bool result, string message) createAccountClient(AccountDTO account)
        {
            var result = repo.CreateAccount(imapper.Map<Account>(account));
            return (result.IsError, result?.Exception.Message);
        }
        public double getAccountBalance(int clientId)
        {
            double balance = 0;
            GetAccounts(0);
            AccountDTO totalbalance = null;
            foreach (AccountDTO acc in GetAccounts(clientId).accounts)
            {
                totalbalance = acc + totalbalance;
            }
            return totalbalance.Balance;
        }
        public AccountDTO GetAccount(int accountid)
        {
            return Mapper.Map<AccountDTO>(repo.GetAccountById(accountid));
        }
    }
}
