using System;


namespace Task9
{
    class Class1
    {
        public static void Main()
        {
            Console.Title = "Task 9";
            try
            {
                Console.WriteLine("Input quantity of numbers:");
                int quantity = Int32.Parse(Console.ReadLine());

                int[] nums = new int[quantity];

                for (int i = 0; i < quantity; i++)
                {
                    Console.WriteLine("Input number:");
                    nums[i] = Int32.Parse(Console.ReadLine());
                }

                int[] minMax = getMinMax(nums);

                Console.WriteLine("\nMinimum and maximum of your numbers: " + minMax[0] + ", " + minMax[1]);


            } catch
            {
                Console.WriteLine("Error");
            }
            Console.ReadKey();
        }

        static int[] getMinMax(params int[] args)
        {
            
            int[] minMax = new int[2];

            int min = args[0];
            int max = args[0];

            foreach(int num in args)
            {
                if (num > max)
                {
                    max = num;
                }
                if (num < min)
                {
                    min = num;
                }
            }
            minMax[0] = min;
            minMax[1] = max;
            return minMax;
        }
    }
}
