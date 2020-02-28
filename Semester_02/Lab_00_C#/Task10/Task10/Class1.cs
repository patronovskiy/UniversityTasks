using System;

namespace Task10
{
    class Class1
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Input your text: ");
                string text = Console.ReadLine();

                Console.WriteLine("How many symbols do you want to add to this text?");
                int quantity = Int32.Parse(Console.ReadLine());

                char[] chars = getChars(quantity);
                string result = getString(text, chars);
                Console.WriteLine("Your new text:");
                Console.WriteLine(result);
            } catch
            {
                Console.WriteLine("Something wrong, sorry. Try again.");
            }
            Console.ReadKey();
        }

        static string getString(string text, params char[] chars)
        {
            string result = text;

            foreach (char symbol in chars)
            {
                result += symbol.ToString();
            }

            return result;
        }

        static char[] getChars(int quantity)
        {
            char[] chars = new char[quantity];
            for (int i = 0; i < quantity; i++)
            {
                Console.WriteLine("Input 1 symbol:");
                chars[i] = Char.Parse(Console.ReadLine());
            }
            return chars;
        }
    }
}
