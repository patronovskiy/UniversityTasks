using System;

namespace Task13
{
    class MainClass
    {
        public static void Main()
        {
            Console.Title = "Task 13";

            Console.WriteLine("First Object");
            Class1 firstObj = new Class1();
            Console.WriteLine(firstObj.ToString());

            Console.WriteLine("Second Object");
            Class1 secondObj = new Class1(' ', "This is an object");
            Console.WriteLine(secondObj.ToString());

            Console.WriteLine("Third Object");
            Class1 thirdObj = new Class1('z', "This is an object");
            Console.WriteLine(thirdObj.ToString());

            Console.ReadKey();
        }
    }

    public class Class1
    {
        private char symbol;
        private string text;

        public Class1()
        {
            symbol = 'A';
            text = "aaAaaaaAaaaAaaaaa";
            Console.WriteLine("Default constructor. Char field: " + this.symbol + ", text field: " + text + "\n");
        }

        public Class1(char symbolArg, string textArg)
        {
            this.symbol = symbolArg;
            this.text = textArg;
            Console.WriteLine("Char field: " + this.symbol + ", text field: " + text + "\n");
        }

        public string[] getSubStrings()
        {
            char[] chars = text.ToCharArray();
            int points = 1;
            string[] subs;
            string Str = "";

            for (int i = 0; i < this.text.Length; i++)
            {
                if (text[i] == this.symbol)
                {
                    points++;
                }
            }
                        
            subs = new string[points];
            if (points == 1)
            {
                subs[0] = this.text;
                Console.WriteLine("There are no symbols '" + this.symbol + "' in the text field.");
                return subs;
            }

            int index = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (text[i] != this.symbol && i != chars.Length - 1)
                {
                    Str += text[i];
                } else
                {
                    subs[index] = Str;
                    Str = "";
                    index++;
                }
            }
            if (text[text.Length - 1] != this.symbol)
            {
                subs[subs.Length - 1] += text[text.Length - 1];
            }
            ;
            return subs;
        }

        public override String ToString()
        {
            string subs = "";
            foreach (string Str in this.getSubStrings())
            {
                subs += Str + "\n";
            }
            return "Text field: " + this.text + ", char field: " + this.symbol + "\n" + "Substrings:\n" + subs;
        }
    }
}
