public class UserInput : IUserInput
{
    public string GetValidateStringInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty.");
                continue;
            }

            return input;
        }
    }

    public int GetValidateIntInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine()?.Trim() ?? "";

            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            return value;
        }
    }

    public decimal GetValidateDecimalInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine()?.Trim() ?? "";

            if (!decimal.TryParse(input, out decimal value))
            {
                Console.WriteLine("Please enter a valid price.");
                continue;
            }

            return value;
        }
    }
}
