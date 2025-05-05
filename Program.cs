class Program
{
    static void Main(string[] args)
    {
        int number;
        int number2;

        Console.WriteLine("Type a number between 1 and 100 (for the other player to guess):");
        number = Convert.ToInt32(Console.ReadLine());

        if (number < 1 || number > 100)
        {
            Console.WriteLine("Number is not between 1 and 100");
            Environment.Exit(0);
        }

        do
        {
            Console.WriteLine("Guess the number:");
            number2 = Convert.ToInt32(Console.ReadLine());

            if (number2 == number)
            {
                Console.WriteLine("You guessed the number!");
            }
            else if (number2 > number)
            {
                Console.WriteLine("The number is lower");
            }
            else
            {
                Console.WriteLine("The number is higher");
            }

        } while (number != number2);
    }
}
