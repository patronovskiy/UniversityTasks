using System;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            TextArray obj = new TextArray("И", "в", "том", "краю", "в", "лихом", "бою", "мы", "будем", "петь", "печаль", "свою");
            obj.show();

            Console.WriteLine("Get element # 9: " + obj[9] +"\n");
            Console.WriteLine("Get element # 15: " + obj[15] + "\n");
            Console.WriteLine("Set obj[11] = \"твою\"");
            obj[11] = "твою";
            obj.show();

            Console.WriteLine("Get element # 5: " + obj[5] + "\n");
            Console.WriteLine("Get obj[5, 2]: " + obj[5, 2] + "\n");
            Console.WriteLine("Get obj[5, 6]: " + obj[5, 10] + "\n");


        }
    }

    class TextArray
    {
        private string[] array;

        public TextArray(params string[] texts)
        {
            array = texts;
        }

        public string this[int index]
        {
            get
            {
                index = index % this.array.Length;
                return this.array[index];
            }
            set
            {
                index = index % this.array.Length;
                this.array[index] = value;
            }
        }

        public char this[int index, int charIndex]
        {
            get
            {
                charIndex = charIndex % array[index].Length;
                char[] chars = array[index].ToCharArray();
                return chars[charIndex];
            }
        }

        public void show()
        {
            Console.WriteLine("Text array (length " + this.array.Length +") :");
            int counter = 0;
            foreach (string text in array)
            {
                if (counter < 6)
                {
                    Console.Write(text + " ");
                    counter++;
                } else
                {
                    Console.WriteLine(text);
                    counter = 0;   
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
