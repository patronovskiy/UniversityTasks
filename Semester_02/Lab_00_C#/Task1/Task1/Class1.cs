using System;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace Task1
{
    class Task1
    {
        static void Main()
        {
            Console.WriteLine("First - console mode, second - dialog mode");
            Console1_09.GetNumbers();
            Dialog1_09.GetNumbers();
        }
    }

    class Console1_09
    {
        public static void GetNumbers()
        {
            Console.WriteLine("Input number: ");
            int num = Int32.Parse(Console.ReadLine());
            Console.WriteLine((num - 1) + " " + num + " " + (num + 1));
            Console.WriteLine("Enter any key");
            Console.ReadKey();
        }
    }

    class Dialog1_09
    {
        public static void GetNumbers()
        {
            String answer = Interaction.InputBox("Input number: ", "Number");
            int num = Int32.Parse(answer);
            MessageBox.Show((num - 1) + " " + num + " " + (num + 1));
        }
    }
}
