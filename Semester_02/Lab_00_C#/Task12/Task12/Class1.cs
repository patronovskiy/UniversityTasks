using System;

namespace Task12
{
    class Class1
    {
        private static int N = 100;
        public static double cos(double x)
        {
            double s = 0, q = 1;
            for (int k = 0; k <= N; k++)
            {
                s += q;
                q *= (-1) * x * x / (2 * k + 1) / (2 * k + 2);
            }
            return s;
        }

        public static double sh(double x)
        {
            double s = 0, q = x;
            for (int k = 0; k <= N; k++)
            {
                s += q;
                q *= x * x / (2 * k + 2) / (2 * k + 3);
            }
            return s;
        }

        public static double ch(double x)
        {
            double s = 0, q = 1;
            for (int k = 0; k <= N; k++)
            {
                s += q;
                q *= x * x / (2 * k + 1) / (2 * k + 2);
            }
            return s;
        }

        public static void Main()
        {
            Console.WriteLine("Cosine of 0: " + Class1.cos(0));
            Console.WriteLine("Cosine of 1: " + Class1.cos(1));
            Console.WriteLine();

            Console.WriteLine("Hyperbolic Sine of 0: " + Class1.sh(0));
            Console.WriteLine("Hyperbolic Sine of 1: " + Class1.sh(1));
            Console.WriteLine();

            Console.WriteLine("Hyperbolic Cosine of 0: " + Class1.ch(0));
            Console.WriteLine("Hyperbolic Cosine of 1: " + Class1.ch(1));

            Console.ReadKey();
        }
    }
}
