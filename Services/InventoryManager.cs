public class InventoryManager : IInventoryManager
{
    private readonly ProductRepository _inventory;
    private readonly UserInput _userInput;

    public InventoryManager(ProductRepository inventory, UserInput userInput)
    {
        _inventory = inventory;
        _userInput = userInput;
    }

    public void AddProduct()
    {
        Console.Clear();
        string id = _userInput.GetValidateStringInput("Product ID: ");

        if (_inventory.GetAll().Any(p => p.Id == id))
        {
            Console.WriteLine($"Product with {id} already exist.");
            return;
        }

        string name = _userInput.GetValidateStringInput("Product name: ");

        if (_inventory.GetAll().Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Product with {name} already exist.");
            return;
        }

        int quantity = _userInput.GetValidateIntInput("Quantity: ");

        decimal price = _userInput.GetValidateDecimalInput("Price: ");

        var newProduct = new Product(id, name, quantity, price);
        _inventory.GetAll().Add(newProduct);

        Console.WriteLine("Product Added!");
        Console.WriteLine($"ID: {id} | Name: {name} | Quantity: {quantity} | Price: {price:C}");
    }

    public void ShowAllProduct()
    {
        if (_userInput.IsProductEmpty())
        {
            Console.WriteLine("Product is empty.");
            return;
        }
        else
        {
            foreach (var product in _inventory.GetAll())
            {
                Console.WriteLine(
                    $"ID: {product.Id} | Name: {product.Name} | Quantity: {product.Quantity} | Price: {product.Price:C} | Total Value: {product.TotalValue:C}"
                );
            }
        }
    }

    public void FindProduct()
    {
        if (_userInput.IsProductEmpty())
        {
            Console.WriteLine("Product is empty.");
            return;
        }

        Console.Clear();

        string id = _userInput.GetValidateStringInput("Product ID: ");

        var products = _inventory.GetAll().FirstOrDefault(p => p.Id == id);

        if (products == null)
        {
            Console.WriteLine($"Product with ID: {id} not exist");
            return;
        }

        Console.WriteLine($"Product with ID: {id} was found.");
        Console.WriteLine(
            $"ID: {products.Id} | Name: {products.Name} | Quantity: {products.Quantity} | Price: {products.Price:C} | Total Value: {products.TotalValue:C}"
        );
    }

    public void DeleteProduct()
    {
        if (_userInput.IsProductEmpty())
        {
            Console.WriteLine("Product is empty.");
            return;
        }

        Console.Clear();

        Console.WriteLine("Current Product:");
        ShowAllProduct();

        string id = _userInput.GetValidateStringInput("Product ID: ");

        var product = _inventory.GetAll().FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            Console.WriteLine($"Product with ID: {id} not exist.");
            return;
        }

        _inventory.GetAll().Remove(product);
        Console.WriteLine($"Product with ID: {id} was removed.");
    }

    public void UpdateQuantityProduct()
    {
        if (_userInput.IsProductEmpty())
        {
            Console.WriteLine("Product is empty.");
            return;
        }

        Console.Clear();

        string id = _userInput.GetValidateStringInput("Product ID: ");

        var product = _inventory.GetAll().FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            Console.WriteLine($"Product with ID: {id} not exist.");
            return;
        }

        bool isRunning = true;

        while (isRunning)
        {
            string choice = _userInput.GetValidateStringInput("Choice: ");

            switch (choice)
            {
                case "1":
                    break;
            }
        }
    }
}
