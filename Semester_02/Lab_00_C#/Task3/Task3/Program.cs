using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Task 3";
            Console.WriteLine("Установить 4 бит числа равным нулю");
            Console.WriteLine("Input number");
            int number = Int32.Parse(Console.ReadLine());
            String binaryNumber = Convert.ToString(number, 2);
            Console.WriteLine("Your number in binary system: ");
            Console.WriteLine(binaryNumber);

            long result = number & 4294967287;

            // 4294967287 in binary is 1111 1111 1111 1111 1111 1111 1111 0111‬, 
            //it is a maximum value of uint with the 4th bit that equals 0
            binaryNumber = Convert.ToString(result, 2);

            Console.WriteLine("Convert the 4th bit to zero:");
            Console.WriteLine(binaryNumber);
            Console.WriteLine("In decimal system this number is " + result);

        }
    }

}
