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

    public abstract class  Organism    
    {
        public string name { get; set; }
        public double movespeed { get; set; }
        public abstract void Move();
        public abstract void Breathe();

        public virtual void Eat()
        {
            Console.WriteLine("*gasp");
        }
    }

    public class dog : Organism
    {
        public override void Move()
        {
            Console.WriteLine("pant pant pant");
        }
        public override void Breathe()
        {
            Console.WriteLine("woof woof woof");
        }
        public override void Eat()
        {
            Console.WriteLine("munch munnch munch");
        }
    }
    public class amoeba : Organism
    {
        public override void Move()
        {
            Console.WriteLine("*slither... *slither...");
        }
        public override void Breathe()
        {
            Console.WriteLine("*no sound...");
        }
        public override void Eat()
        {
            base.Eat();
        }
    }
    public sealed class volee : dog
    {
        public override void Move()
        {
            Console.WriteLine("pant pant pant");
        }
        public override void Breathe()
        {
            Console.WriteLine("woof woof woof");
        }
        public override void Eat()
        {
            Console.WriteLine("i am the same as the dog but with a cool name");
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
