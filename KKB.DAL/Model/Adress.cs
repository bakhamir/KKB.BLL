using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.DAL.Model
{
    public class Adress
    {
        public int id { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string street { get; set; }
        public string home { get; set; }
    }
}
