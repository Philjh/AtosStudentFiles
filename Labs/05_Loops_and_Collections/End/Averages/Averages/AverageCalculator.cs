internal class AverageCalculator
{
    internal void AveragesWithWhile()
    {
        double total = 0.0;
        int count = 0;

        Console.Write("Enter the first number, or Q to quit: ");
        string input = Console.ReadLine();
        while (input.ToUpper() != "Q")
        {
            total += double.Parse(input);
            count++;

            Console.Write("Enter another number, or Q to quit: ");
            input = Console.ReadLine();
        }
        if (count == 0)
        {
            Console.WriteLine("You didn't enter any numbers");
        }
        else
        {
            Console.WriteLine($"The average of those numbers is {total / count}");
        }

    }

    internal void AveragesWithDoWhile()
    {
        double total = 0.0;
        int count = 0;
        string input;

        do
        {
            Console.Write("Enter a number, or Q to quit: ");
            input = Console.ReadLine();

            if (input.ToUpper() != "Q")
            {
                total += double.Parse(input);
                count++;
            }

        } while (input.ToUpper() != "Q");

        if (count == 0)
        {
            Console.WriteLine("You didn't enter any numbers");
        }
        else
        {
            Console.WriteLine($"The average of those numbers is {total / count}");
        }

    }

    internal void AveragesWithFor()
    {
        double total = 0.0;
        Console.Write("How many numbers do you have? ");
        int count = int.Parse(Console.ReadLine());

        for (int index = 0; index < count; index++)
        {
            Console.Write($"({index + 1}) - Enter a number: ");
            total += double.Parse(Console.ReadLine());
        }
        if (count == 0)
        {
            Console.WriteLine("You didn't enter any numbers");
        }
        else
        {
            Console.WriteLine($"The average of those numbers is {total / count}");
        }

    }
}