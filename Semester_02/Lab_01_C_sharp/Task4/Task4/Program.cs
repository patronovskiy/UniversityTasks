using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IndexedClass obj1 = new IndexedClass();
            obj1.show();

            obj1[0] = 5;
            Console.WriteLine("Set obj1[0] = 5");
            obj1.show();

            obj1[5] = 12;
            Console.WriteLine("Set obj1[5] = 12");
            obj1.show();

            obj1[3] = 999;
            Console.WriteLine("Set obj1[3] = 999");
            obj1.show();

            obj1[0] = 18;
            Console.WriteLine("Set obj1[0] = 18");
            obj1.show();

            obj1[5] = 0;
            Console.WriteLine("Set obj1[5] = 0");
            obj1.show();
        }
    }

    class IndexedClass
    {
        private uint number;

        public uint this[uint index]
        {
            set
            {
                value = value % 10;
                uint multiple;
                if (index == 0)
                {
                    multiple = 1;
                } else
                {
                    multiple = 1;
                    for (int i = 0; i < index; i++)
                    {  
                        multiple *= 10;
                    }
                }
                if (multiple > number)
                {
                    number = value * multiple + number;
                } else
                {
                    uint rest = number - ((number / multiple) * multiple);
                    number = ((number / (multiple * 10)) * (multiple * 10) + value * multiple + rest);
                }
 
            }
        } 
        public void show()
        {
            Console.WriteLine("The value of number: " + this.number);
        }
    }
}
