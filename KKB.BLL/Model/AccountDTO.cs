using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.Model
{
    public class AccountDTO
    {
        public AccountDTO()
        {

        }
        public AccountDTO(int Currence, double Bakance)
        {
            this.Currence = Currence;
            this.Balance = Bakance;
        }
        public int Id { get; set; }
        public double Balance { get; set; }
        public int Currence { get; set; }

        public static AccountDTO operator +(AccountDTO acc1, AccountDTO acc2)
        {
            if(acc1.Currence != acc2.Currence)
            {
                throw new InvalidOperationException("Не суммируйте денбги в разной валюте");
            }
            else
            {
                return new AccountDTO(acc1.Currence,acc1.Balance + acc2.Balance);
            }
        }



        public int Clientid { get; set; }

        public double Limit { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool Status { get; set; } = true;
        public int TypeCard { get; set; } //debit - credit
        public string IBAN { get; set; } //KZ05403542054C854


        public double DaysRemain
        {
            get
            {
                return (ExpireDate - CreateDate).TotalDays;
            }
        }

        public bool IdActive
        {
            get
            {
                return Status;
            }
        }
        public static bool operator ==(AccountDTO acc1, AccountDTO acc2)
        {
            if (acc1.Currence != acc2.Currence)
            {
                throw new InvalidOperationException("Неверный аргумент");
            }
            return acc1.Balance == acc2.Balance;
        }
        public static bool operator !=(AccountDTO acc1, AccountDTO acc2)
        {
            if (acc1.Currence != acc2.Currence)
            {
                throw new InvalidOperationException("Неверный аргумент");
            }
            return acc1.Balance == acc2.Balance;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Id, IBAN, Balance);
        }
        public static explicit operator string(AccountDTO acc)
        {
            return string.Format("{0} {1} {2}", acc.Id, acc.IBAN, acc.Balance);
        }
        public static explicit operator ShortAccount(AccountDTO acc)
        {
            return new ShortAccount();
        }
    }
    
}
