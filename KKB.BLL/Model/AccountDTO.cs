using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.Model
{
    public class AccountDTO
    {
        public AccountDTO()
        {
            
        }

        public AccountDTO(int Currence, double Balance)
        {
            this.Currence = Currence;
            this.Balance = Balance;
        }

        public int Id { get; set; }
        public int ClientId { get; set; }

        public double Balance { get; set; }
        public int Currence { get; set; }

        public static explicit operator ShortAccount(AccountDTO acc)
        {
            return new ShortAccount();
        }

        public static AccountDTO operator +(AccountDTO acc1, AccountDTO acc2)
        {
            if(acc1.Currence!=acc2.Currence)
                throw new InvalidOperationException("Нельзя суммировать деньги разных валют");

            return new AccountDTO(acc1.Currence, acc1.Balance+acc2.Balance);
        }

        //public static bool operator ==(AccountDTO acc1, AccountDTO acc2)
        //{
        //    if (acc1.Currence != acc2.Currence)
        //        throw new InvalidOperationException("Нельзя сравнивать деньги разных валют");

        //    return acc1.Balance == acc2.Balance;
        //}

        //public static bool operator !=(AccountDTO acc1, AccountDTO acc2)
        //{
        //    if (acc1.Currence != acc2.Currence)
        //        throw new InvalidOperationException("Нельзя сравнивать деньги разных валют");

        //    return acc1.Balance == acc2.Balance;
        //}

        public static AccountDTO operator ++(AccountDTO acc)
        {
            return new AccountDTO(acc.Currence, acc.Balance+1);
        }

        public static explicit operator string(AccountDTO acc)
        {
            return string.Format("{0}. {1}\t{2}", 
                acc.Id, acc.IBAN, acc.Balance);
        }


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
    }
}
