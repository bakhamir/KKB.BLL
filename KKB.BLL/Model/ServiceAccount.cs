using AutoMapper;
using KKB.DAL;
using KKB.DAL.Interfaces;
using KKB.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.Model
{
    public class ServiceAccount
    {
        private readonly IRepository<Account> repo = null;
        private readonly IMapper iMapper;

        public ServiceAccount(string connectionString)
        {
            repo = new Repository<Account>(connectionString);
            iMapper = BLLSettings.Init().CreateMapper();
        }

        /// <summary>
        /// Метод возвращает список счетов пользователя
        /// </summary>
        /// <returns></returns>
        public (string message, List<AccountDTO> accounts) GetAllAccounts(int clientId)
        {
            var result = repo.Get();
  
            return ((result.IsError==true) ? result.Exception.Message : "", 
                iMapper.Map<List<AccountDTO>>(result
                                               .Datas.Where(w => w.ClientId.Equals(clientId))));
        }

        //public double GetAccountBalance(int clientId)
        //{
        //    AccountDTO totalBalance = null;
        //    foreach (AccountDTO acc in GetAllAccounts(clientId).accounts)
        //    {
        //        totalBalance = acc + totalBalance;
        //    }

        //    return totalBalance.Balance;
        //}

        //public static void Exmpl01()
        //{
        //    AccountDTO acc1 = new AccountDTO(1, 1000);
        //    AccountDTO acc2 = new AccountDTO(1, 2000);
        //    AccountDTO acc3 = new AccountDTO(3, 1000);

        //    var result = acc1 + acc2;
        //    var result2 = acc2 + acc3;
        //}

        public (bool result, string message) CreateAccountClient(AccountDTO account)
        {
            var result = repo.Create(iMapper.Map<Account>(account));

            return (result.IsError, result.Exception!=null ?
                result.Exception.Message : "");
        }

        /// <summary>
        /// Метод который возвращает информацию по счету
        /// </summary>
        /// <param name="accountId">ID счета</param>
        /// <returns></returns>
        public AccountDTO GetAccount(int accountId)
        {
            return iMapper.Map<AccountDTO>(repo.GetData(accountId).Datas);
        }
    }
}
