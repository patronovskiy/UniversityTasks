using System;
using Microsoft.VisualBasic;
using System.Windows.Forms;

//chapter 2, task 10

namespace Task2
{
    class Task2
    {
        static void Main()
        {
            Console.WriteLine("1 - console, 2 - dialog");
            Console2.GetSumAndDif();
            Dialog2.GetSumAndDif();
        }
    }

    class Console2
    {
        public static void GetSumAndDif()
        {
            Console.Title = "The First number";
            Console.WriteLine("Input first number: ");
            int first = Int32.Parse(Console.ReadLine());
            Console.Title = "The Second number";
            Console.WriteLine("Input second number: ");
            int second = Int32.Parse(Console.ReadLine());

            Console.Title = "Sum and difference";
            Console.WriteLine("Sum of numbers: " + (first + second));
            Console.WriteLine("Difference of numbers: " + (first - second));
            Console.WriteLine("Enter any key");
            Console.ReadKey();
        }
    }

    class Dialog2
    {
        public static void GetSumAndDif()
        {
            String answer_1 = Interaction.InputBox("Input the first number: ", "The first number");
            int first = Int32.Parse(answer_1);

            String answer_2 = Interaction.InputBox("Input the second number: ", "The second number");
            int second = Int32.Parse(answer_2);

            int sum = first + second;
            int dif = first - second;

            MessageBox.Show("Sum of numbers: " + sum +"\nDifference of numbers: " + dif);

        }
    }


}
