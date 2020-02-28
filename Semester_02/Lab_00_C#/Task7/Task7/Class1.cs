using System;

namespace Task7
{
    class Task7
    {
        public static void Main()
        {
            Console.Title = "Task 7";

            int[,] arr = getArray(10, 10);
            Console.WriteLine("Initial array: ");
            PrintArray(arr);

            int[] nums = getNumbers();
            Console.WriteLine("Cut row # {0}, column # {1}", nums[0], nums[1]);

            int[,] newArr = cutArray(arr, nums);
            Console.WriteLine("Cutted array: ");
            PrintArray(newArr);

            Console.ReadKey();
        }

        public static int[] getNumbers()
        {
            Random rand = new Random();
            int[] nums = new int[2];
            nums[0] = rand.Next(0, 9);
            nums[1] = rand.Next(0, 10);

            return nums;
        }

        public static int[,] getArray(int rows, int cols)
        {
            Random rand = new Random();
            int[,] arr = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = rand.Next(10, 99);
                }
            }
            return arr;
        }

        public static void PrintArray(int[,] arr) 
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static int[,] cutArray(int[,] arr, int[] nums) 
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);

            int[,] newArr = new int[rows - 1, cols - 1];

            for (int i = 0, current_row = 0; i < rows - 1; i++, current_row++)
            {
                for (int j = 0, current_col = 0; j < cols - 1; j++, current_col++)
                {
                    if (current_row == nums[0])
                    {
                        current_row++;
                    }
                    if (current_col == nums[1])
                    {
                        current_col++;
                    }
                    newArr[i, j] = arr[current_row, current_col];
                }
            }
            return newArr;
        }
    }
}
