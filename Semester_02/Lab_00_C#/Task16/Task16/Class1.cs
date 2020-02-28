using System;

namespace Task16
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

            int randRow = rand.Next(0, rows);

            int randCol = rand.Next(0, cols);

            Console.WriteLine("\nDelete row # " + randRow + " and column # " + randCol + "\n");

            Console.WriteLine("Cuted array: \n");

            int[,] newArr = new int[rows - 1, cols - 1];

            for (int i = 0; i < rows - 1; i++)
            {

                for (int j = 0; j < cols - 1; j++)
                {

                    if (i != randRow && j != randCol)
                    {

                        newArr[i, j] = arr[i, j];

                        Console.Write(arr[i, j] + " ");

                    }

                }

                if (i != randRow)
                {

                    Console.WriteLine();

                }

            }
            Console.ReadKey();
        }

    }
}
