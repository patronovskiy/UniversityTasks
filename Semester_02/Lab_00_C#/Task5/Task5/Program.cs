using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "Task 5. Variant with 'for' cycle";
                Console.WriteLine("Variant with 'for' cycle\n");
                getNumbersFor();

            } catch
            {
                Console.Title = "Error";
                Console.WriteLine("Error. You had to input a number.\n");
            }

            try
            {
                Console.Title = "Task 5.Variant with 'while' cycle";

                Console.WriteLine("Variant with 'while' cycle\n");
                getNumbersWhile();
            }
            catch
            {
                Console.Title = "Error";
                Console.WriteLine("Error. You had to input a number.\n");
            }
        }

        public static void getNumbersFor()
        {
            int[] nums = new int[2];
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Input number:");
                nums[i] = Int32.Parse(Console.ReadLine());
            }
            if (nums[0] > nums[1])
            {
                Console.WriteLine(nums[1] + " " + nums[0] + "\n");
            } else
            {
                Console.WriteLine(nums[0] + " " + nums[1] + "\n");
            }
        }

        public static void getNumbersWhile()
        {
            int i = 0;
            int[] nums = new int[2];
            while (i<2)
            {
                Console.WriteLine("Input number:");
                nums[i] = Int32.Parse(Console.ReadLine());
                i++;
            }
            if (nums[0] > nums[1])
            {
                Console.WriteLine(nums[1] + " " + nums[0] + "\n");
            }
            else
            {
                Console.WriteLine(nums[0] + " " + nums[1] + "\n");
            }
        }
    }
}
