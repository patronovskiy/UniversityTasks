using System;

public class Task6
{
    public static void Main()
    {
        try
        {
            int quantity = getQuantity();
            getNumbersWhile(quantity);
        } catch
        {
            Console.WriteLine("Error. You had to input a positive number");
        }
        Console.ReadLine();

    }

    public static int getQuantity()
    {
        int quantity;
 
            Console.WriteLine("Input quantity of numbers: ");
            quantity = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Quantity of numbers is " + quantity);

        return quantity;
    }

    public static void getNumbersWhile(int quantity)
    {
        if (quantity <= 0)
        {
            Console.WriteLine("There is no numbers");
        }
        else
        {
            int[] nums = new int[quantity];
            int current = 1;
            int index = 0;
            long sum = 0;

            Console.WriteLine("Numbers: ");
            while (index < quantity)
            {
                if (current % 5 == 2 || current % 3 == 1)
                {
                    nums[index] = current;
                    sum += current;
                    Console.Write(current + ", ");
                    index++;
                }
                current++;
            }
            Console.WriteLine("\nSum of these numbers: " + sum);

        }
    }
}

