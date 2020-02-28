using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task15
{
    public class Program

    {

        public static void Main()

        {

            int rows = 8, cols = 13;

            int[,] arr = new int[rows, cols];

            var rand = new Random();

            Console.WriteLine("Initial array:\n ");

            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < cols; j++)
                {

                    arr[i, j] = rand.Next(10, 99);

                    Console.Write(arr[i, j] + " ");

                }

                Console.WriteLine();

            }

            Console.WriteLine("\nInverted array:\n ");

            int[,] newArr = new int[cols, rows];

            for (int i = 0; i < cols; i++)
            {

                for (int j = 0; j < rows; j++)
                {

                    newArr[i, j] = arr[j, i];

                    Console.Write(newArr[i, j] + " ");

                }

                Console.WriteLine();

            }
            Console.ReadKey();
        }
    }
}
