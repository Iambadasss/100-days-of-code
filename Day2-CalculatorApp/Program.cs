
class Program
{
    static void Main()
    {
        string repeat;
        do
        {
            Console.Write("Enter the first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Choose an operation (+, -, *, /): ");
            string op = Console.ReadLine();

            double result = 0;
            bool valid = true;

            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Cannot divide by zero!");
                        valid = false;
                    }
                    else
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    valid = false;
                    break;
            }

            if (valid)
            {
                Console.WriteLine($"Result: {result}");
            }

            Console.Write("Do you want to calculate again? (yes/no): ");
            repeat = Console.ReadLine().ToLower();

        } while (repeat == "yes");

        Console.WriteLine("Goodbye!");
    }
}
