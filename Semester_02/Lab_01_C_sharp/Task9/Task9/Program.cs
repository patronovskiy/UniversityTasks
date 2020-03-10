using System;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass Base = new BaseClass(5);
            Console.WriteLine("Base class: ");
            Base.show();
            for (int i = 0; i < 5; i++)
            {
                Base[i] = i;
            }
            Base.show();
            Console.WriteLine();

            SubClass Sub = new SubClass(5, 3);
            Console.WriteLine("Sub class: ");
            Sub.show();
            for (int i = 0; i < 5; i++)
            {
                Sub[i] = i;
            }
            Sub['a'] = 'a';
            Sub['b'] = 'b';
            Sub['c'] = 'C';
            Sub.show();
            Console.WriteLine();
        }
    } 

    class BaseClass
    {
        protected int[] array;

        public BaseClass(int size)
        {
            this.array = new int[size];
        }

        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }

        public int Size
        {
            get
            {
                return array.Length;
            }
        }

        public virtual void show()
        {
            Console.WriteLine("Class: " + this.GetType());
            Console.WriteLine("Fields: ");
            string str = "";
            foreach(int i in array)
            {
                str += i + " ";
            }
            Console.WriteLine("\tarray: " + str);
            Console.WriteLine("\tSize: " + this.Size);
        }
    }

    class SubClass : BaseClass
    {
        protected char[] charArray;

        public SubClass(int size1, int size2): base(size1)
        {
            this.charArray = new char[size2];
        }

        public char this[char charIndex]
        {
            get
            {
                int index = charIndex - 'a';
                if (index >= charArray.Length)
                {
                    index %= charArray.Length;
                }
                else if (index < 0)
                {
                    index = 0;
                }
                return charArray[index];
            }
            set
            {
                int index = charIndex - 'a';
                if (index >= charArray.Length)
                {
                    index %= charArray.Length;
                }
                else if (index < 0)
                {
                    index = 0;
                }
                charArray[index] = value;
            }
        }

        new public int[] Size
        {
            get
            {
                int[] sizes= new int[2];
                sizes[0] = this.array.Length;
                sizes[1] = this.charArray.Length;
                return sizes;
            }
        }

        public override void show()
        {
            Console.WriteLine("Class: " + this.GetType());
            Console.WriteLine("Fields: ");
            string str = "";
            foreach (int i in array)
            {
                str += i + " ";
            }
            Console.WriteLine("\tarray: " + str);
            string str1 = "";
            foreach (char c in charArray)
            {
                str1 += c + " ";
            }
            Console.WriteLine("\tcharArray: " + str1);
            Console.WriteLine("\tSize: " + this.Size[0] + ", " + this.Size[1]);
        }
    }
}
