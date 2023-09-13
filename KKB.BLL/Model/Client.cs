using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.Model
{
    internal class Client
    {
        public int id { get; set; }
        public string name { get; set; }

        public string surname { get; set; }
        public string fatherName { get; set; }
        public DateTime created { get; set; }
        public int GetAge
        {
            get
            {
                return DateTime.Now.Year - created.Year;
            }
        }
        public int number { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int gender { get; set; }
        public Adress[] Adress { get; set; }
        public Account[] account { get; set; }
    }
}
