using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            TwoDimensial obj = new TwoDimensial(4, 5);
            Console.WriteLine("Initial array:");
            obj.show();

            Console.WriteLine("Get obj[2,3]: " + obj[2, 3]);
            obj.show();

            Console.WriteLine("Set obj[2,3] = 18");
            obj[2, 3] = 18;
            obj.show();

            Console.WriteLine("Get obj[0]: " + obj[0]);
            obj.show();

            Console.WriteLine("Set obj[0] = -1");
            obj[0] = -1;
            obj.show();
        }

        class TwoDimensial
        {
            private int[,] array;

            public TwoDimensial(int rows, int cols)
            {
                this.array = new int[rows, cols];
                Random rand = new Random();
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = rand.Next(0, 9);
                    }
                }
            }

            public int this [int row, int col]
            {
                set
                {
                    array[row, col] = value;
                }
                get
                {
                    return array[row, col];
                }
            }


            public int this[int row]
            {
                set
                {
                    int index = getFirstMaxIndex(row);
                    array[row, index] = value;
                }

                get
                {
                    int index = getFirstMaxIndex(row);
                    return array[row, index];
                }
            }

            private int getFirstMaxIndex (int row)
            {
                int index = 0;
                int max = this.array[row, 0];

                for (int i = 0; i < array.GetLength(1); i++)
                {
                    if (array[row, i] > max)
                    {
                        max = array[row, i];
                        index = i;
                    }
                }
                return index;
            }

            public void show()
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write(array[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

        }
    }
}
