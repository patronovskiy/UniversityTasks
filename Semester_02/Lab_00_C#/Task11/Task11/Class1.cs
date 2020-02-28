using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    class Class1
    {
        static int getMin(params int[] args)
        {
            int min = 0;
            if (args.Length != 0)
            {
                min = args[0];
            }
            foreach (int num in args)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            return min;
        }

        static int getMax(params int[] args)
        {
            int max = 0;
            if (args.Length != 0)
            {
                max = args[0];
            }
            foreach (int num in args)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        }

        static int getAverage(params int[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("There are no numbers");
            }
            int sum = 0;
            foreach(int num in args)
            {
                sum += num;
            }

            int average = sum / args.Length;
            return average;
        }

        public static void Main()
        {
            int[] nums = { 1, 3, -8, 99, 0, 10, 2, 4, 777 };

            Console.WriteLine("Numbers: ");
            foreach(int num in nums)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine("\nMinimum: " + Class1.getMin(nums));

            Console.WriteLine("Maximum: " + Class1.getMax(nums));

            Console.WriteLine("Average: " + Class1.getAverage(nums));

            Console.ReadKey();
        }

    }

}
