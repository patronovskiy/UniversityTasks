using System;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Base object");
            Base obj1 = new Base();
            obj1.setNumber(105117839);
            Console.WriteLine("Value of number is " + obj1.number);
            Console.WriteLine("obj1[0] is " + obj1[0]);
            Console.WriteLine("obj1[4] is " + obj1[4]);

            Console.WriteLine("Inherited object");
            Inherited obj2 = new Inherited();
            obj2.setNumber(12345, 6789);
            Console.WriteLine("\nValue of 1st number field is " + obj2.number + 
                                ", value of 2nd number field is " + obj2.secondNumber);
            Console.WriteLine("Sum of fields: " + obj2.number + " + " + obj2.secondNumber + " = " + (obj2.number + obj2.secondNumber));
            Console.WriteLine("obj2[1, 0] is " + obj2[1, 0]);
            Console.WriteLine("obj1[2, 0] is " + obj2[2, 0]);
            Console.WriteLine("obj1[0] is " + obj2[0]);
        }
    }

    class Base
    {
        public int number;

        public int this[int index] {
            get {
                int result;
                if (index == 0)
                {
                    result = this.number % 10;
                } else
                {
                    int zeros = 1;
                    for (int i = 0; i < index; i++)
                    {
                        zeros *= 10;
                    }
                    result = ((number % (zeros * 10)) - (number % zeros)) / zeros;
                }
                return result; 
            }
        }

        public void setNumber(int num)
        {
            this.number = num;
        }
    }

    class Inherited: Base
    {
        public int secondNumber;

        public void setNumber(int num1, int num2)
        {
            this.number = num1;
            this.secondNumber = num2;
        }

        public int this[int order, int index]
        {
            get
            {
                int field = order == 1 ? this.number : this.secondNumber;

                    int result;
                    if (index == 0)
                    {
                        result = field % 10;
                    }
                    else
                    {
                        int zeros = 1;
                        for (int i = 0; i < index; i++)
                        {
                            zeros *= 10;
                        }
                        result = ((field % (zeros * 10)) - (field % zeros)) / zeros;
                    }
                    return result;
            }
        }

        new public int this[int index]
        {
            get
            {
                int field = this.number + this.secondNumber;

                int result;
                if (index == 0)
                {
                    result = field % 10;
                }
                else
                {
                    int zeros = 1;
                    for (int i = 0; i < index; i++)
                    {
                        zeros *= 10;
                    }
                    result = ((field % (zeros * 10)) - (field % zeros)) / zeros;
                }
                return result;
            }
        }

    }
}
