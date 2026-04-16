public class UserInput : IUserInput
{
    private readonly ProductRepository _product;

    public UserInput(ProductRepository product)
    {
        _product = product;
    }

    public bool IsProductEmpty()
    {
        var currentInventory = _product.GetAll();

        return currentInventory == null || currentInventory.Count == 0;
    }

    public string GetValidateStringInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
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
            Console.Write(prompt);
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
            Console.Write(prompt);
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
