using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Task 4";
            Console.WriteLine("Конвертировать 2-й бит числа");
            Console.WriteLine("Введите число в двоичном формате:");
            String binString = Console.ReadLine();
            int decNumber = Convert.ToInt32(binString, 2);
            Console.WriteLine("Your number in decimal: " + decNumber);

            String sub1 = binString.Substring(0, binString.Length - 2);
            String sub2 = binString.Substring(binString.Length - 2, 1);
            String sub3 = binString.Substring(binString.Length - 1, 1);

            sub2 = sub2 == "1" ? "0" : "1";

            String resultBinString = sub1 + sub2 + sub3;
            Console.WriteLine("Convert the 2nd bit:");
            Console.WriteLine(resultBinString);
            Console.WriteLine("This number in decimal system: " + Convert.ToInt32(resultBinString, 2));
        }
    }

}
