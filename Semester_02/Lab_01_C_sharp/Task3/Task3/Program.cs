using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Overrided obj1 = new Overrided('e');
            Overrided obj2 = new Overrided('r');
            Console.Write("Object1. ");
            obj1.show();
            Console.Write("Object2. ");
            obj2.show();

            string text = obj1 + obj2;
            Console.WriteLine("Object1 + Object2 = " + text);

            int diff = obj1 - obj2;
            Console.WriteLine("Object1 - Object2 = " + diff);

        }
    }

    public class Overrided
    {
        private char symbol;

        public Overrided(char symbol)
        {
            this.symbol = symbol;
        }

        public void show()
        {
            Console.WriteLine("Value of char field: " + this.symbol);
        }

        public static string operator + (Overrided obj1, Overrided obj2)
        {
            string text = "" + obj1.symbol + obj2.symbol;
            return text;
        }

        public static int operator - (Overrided obj1, Overrided obj2)
        {
            int diff = obj1.symbol - obj2.symbol;
            return diff;
        }

        //versions of operators for += using and -= using
        /*
        public static Overrided operator + (Overrided obj1, Overrided obj2)
        {
            Overrided res = new Overrided((char) (obj1.symbol + 1));
            return res;
        }

        public static Overrided operator - (Overrided obj1, Overrided obj2)
        {
            Overrided res = new Overrided((char)(obj2.symbol - 1));
            return res;
        }
        */

    }
}
