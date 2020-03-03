using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Task2";
            
            Number num1 = new Number(5);
            Number num2 = new Number(-99);

            Console.Write("Number object # 1. ");
            num1.show();
            Console.Write("Number object # 2. ");
            num2.show();
            Console.WriteLine();

            Number sum = num1 + num2;
            Console.Write("Sum of Number objects: ");
            sum.show();
            sum += sum;
            Console.Write("sum+= sum. Sum now: ");
            sum.show();
            Console.WriteLine();

            Number difference = num1 - num2;
            Console.Write("Difference of Number objects: ");
            difference.show();
            difference -= difference;
            Console.Write("difference -= difference. difference now: ");
            difference.show();
            Console.WriteLine();

            Console.Write("Multiplication of Number objects: ");
            Number multiplication = num1 * num2;
            multiplication.show();
            Console.Write("multiplication *= multiplication. multiplication now: ");
            multiplication *= multiplication;
            multiplication.show();
            Console.WriteLine();

        }
    }

    public class Number
    {
        private int value;

        public Number(int value)
        {
            this.value = value;
        }

        public void show()
        {
            Console.WriteLine("Value: " + this.value);
        }

        public static Number operator + (Number num1, Number num2)
        {
            Number result = new Number(num1.value + num2.value);
            return result;
        }

        public static Number operator - (Number num1, Number num2)
        {
            Number result = new Number(num1.value - num2.value);
            return result;
        }

        public static Number operator * (Number num1, Number num2)
        {
            Number result = new Number(num1.value * num2.value);
            return result;
        }
    }
}
