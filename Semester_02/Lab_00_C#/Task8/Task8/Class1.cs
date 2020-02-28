using System;

namespace Task8
{
    class Class1
    {
        public static void Main()
        {
            int[,] arr = new int[6,4];
            Console.WriteLine("Initial array:");
            PrintArray(arr);

            snakeFull(arr);
            Console.WriteLine("Full array:");
            PrintArray(arr);

            Console.ReadKey();


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

        public static void snakeFull(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            int step = 10;

            int current_row = 0;
            int current_col = cols-1;

            int top = 0;
            int bottom = 0;
            int left = 0;
            int right = 0;
            
            while(top + bottom < rows & left + right < cols)
            {
                if (top < rows - bottom)
                {
                    for (int i = left; i < cols - right; i++) //step 1 ->
                    {
                        arr[current_row, i] = step;
                        step++;
                    }
                    top++;
                    current_row = rows - (1 + bottom);
                }

                if (right < cols - left)
                {
                    for(int i = top; i < rows - bottom; i++)  //step 2 
                    {
                        arr[i, current_col] = step;
                        step++;
                    }
                    right++;
                    current_col = 0 + left;
                }

                if (bottom < rows - top)
                {
                    for (int i = cols - (right + 1); i > left + -1; i--)   //step 3 <-
                    {
                        arr[current_row, i] = step;
                        step++;
                    }
                    bottom++;
                    current_row = top;
                }

                if (left < cols - right)
                {
                    for (int i = rows - (1 + bottom); i > top - 1; i--)
                    {
                        arr[i, current_col] = step;
                        step++;
                    }
                    left++;
                    current_col = cols - right - 1;
                }

            }

        }
    }

}
