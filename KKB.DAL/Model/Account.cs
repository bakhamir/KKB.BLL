using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.DAL.Model
{
    public class Account
    {
        public int Id { get; set; }
        public DateTime createDate { get; set; }
        public double balance { get; set; }
        public int currency { get; set; }
        public int limits { get; set; }
        public DateTime expiration { get; set; }
        public DateTime received { get; set; }
        public bool status {get; set; }
        public bool debitOrCredit { get; set; }
        public string IBAN { get; set; }

        public double daysRemain { get
            {
                return (expiration - received).TotalDays;
            }}

    }
}
