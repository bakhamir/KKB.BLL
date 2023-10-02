using KKB.BLL.Model;
using System;
using System.IO.Ports;
using System.Text;

namespace KKB.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu.FirstMenu();
            Console.ReadKey();
        }
    }

    public static class StringBulderExtension
    {
        public static Int32 IndexOf(this StringBuilder sb, Char value)
        {
            for (int i = 0; i < sb.Length; i++)
            {
                if (sb[i] == value) return i;
            }
            return -1;
        }
    }
}
