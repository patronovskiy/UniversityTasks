using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Task 1";
            
            OverridingClass myObj = new OverridingClass();

            string str = (string) myObj;
            Console.WriteLine("Conversion to string type: " + str);

            int sum = (int)myObj;
            Console.WriteLine("Conversion to int type: " + sum);

            OverridingClass objFromInt = (OverridingClass) 3;
            Console.WriteLine("Object conversed from int 3: " + (string)objFromInt);
        }
    }

    public class OverridingClass
    {
        private int[] arr;
        Random rand = new Random();

        public OverridingClass()
        {
            arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = rand.Next(10);
            }
        }

        public OverridingClass(int size)
        {
            arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(100);
            }
        }

        public OverridingClass(int size, bool isOverrided)
        {
            arr = new int[size];
        }

        public static explicit operator string (OverridingClass obj)
        {
            string str = "";
            foreach (int i in obj.arr)
            {
                str += i + ", ";
            }
            str = str.Substring(0, str.Length - 2);
            return str;
        }

        public static explicit operator int (OverridingClass obj)
        {
            int sum = 0;
            foreach(int i in obj.arr)
            {
                sum += i;
            }
            return sum;
        }

        public static explicit operator OverridingClass(int number)
        {
            OverridingClass newObj = new OverridingClass(number, true);
            return newObj;
        }
    }
}
