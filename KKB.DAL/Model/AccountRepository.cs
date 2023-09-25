using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.DAL.Model
{
    public class AccountRepository
    {
        private readonly string connectionString = "";
        public AccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public AccountReturnResult GetAccounts()
        {
            AccountReturnResult result = new AccountReturnResult();
            result.Accounts = null;
            List<Account> accounts = null;
            try
			{
                using (var db = new LiteDatabase(connectionString))
                {
                    accounts = db.GetCollection<Account>("Account").FindAll().ToList();
                }
            }
			catch (Exception ex)
			{
                result.IsError = true;
                result.Exception = ex;
			}
            return result;
        }
        public AccountReturnResult CreateAccount(Account account)
        {
            AccountReturnResult result = new AccountReturnResult();
            try
            {
                using (var db = new LiteDatabase(connectionString))
                {
                    var accounts = db.GetCollection<Account>("Account");
                    accounts.Insert(account);
                }
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Exception= ex;
            }
            return result;
        }
        public List<Account> GetAccountById(int account)
        {
            using (var db = new LiteDatabase(connectionString))
            {
                var accounts = db.GetCollection<Account>("Account").FindAll().ToList();
                return accounts;
            }

        }
        public AccountReturnResult Pay(Account account,double val)
        {
            AccountReturnResult result = new AccountReturnResult();
            try
            {
                
                using (var db = new LiteDatabase(connectionString))
                {
                    var accounts = db.GetCollection<Account>("Account");
                    accounts.Update(account);
                }
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Exception = ex;
            }
            return result;
        }
    }
}
