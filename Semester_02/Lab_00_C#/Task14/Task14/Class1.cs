using System;


namespace Task14
{
    class Class1
    {
        private int[] array;
        private int quantity = 10;
        private int sum = 0;
        private int average;

        public Class1()
        {
            Random rand = new Random();
            array = new int[quantity];
            for (int i =0; i < quantity; i++)
            {
                array[i] = rand.Next(0, 100);
                sum += array[i];
            }
            average = sum / quantity;
        }

        public Class1(int quantityArg)
        {
            this.quantity = quantityArg;
            Random rand = new Random();
            array = new int[quantity];
            for (int i = 0; i < quantity; i++)
            {
                array[i] = rand.Next(0, 100);
                sum += array[i];
            }
            average = sum / quantity;
        }

        public override string ToString()
        {
            string elems = "";
            foreach(int num in array)
            {
                elems += num + " ";
            }
            return "Elements: " + elems +
                    "\nQuantity of elements: " + quantity +
                    "\nSum of elements: " + sum +
                    "\nAvarage of elements: " + average;
        }

    }

    class MainClass
    {
        public static void Main()
        {
            Class1 MyObject = new Class1(15);
            Console.WriteLine(MyObject.ToString());

            Console.ReadKey();
        }
    }
}
