using KKB.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace KKB.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu.FirstMenu();
            Console.ReadKey();
            AccountDTO acc = new AccountDTO();
            ShortAccount sAcc = (ShortAccount)acc;

            StringBuilder sb = new StringBuilder("nothing lasts forever");
            //int index = StringBuilderExtension.IndexOf();
            sb.IndexOf('s');
        }
    }

    public class Counter
    {
        public int Seconds { get; set; }

        public static implicit operator Counter(int seconds)
        {
            return new Counter { Seconds = seconds };
        }
        public static explicit operator int(Counter counter)
        {
            return counter.Seconds;
        }
    }

    public static class StringBuilderExtension
    {
        public static Int32 IndexOf(this StringBuilder sb,char value)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
