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
        var id = _userInput.GetValidateStringInput("Product ID: ");

        if (_inventory.GetAll().Any(p => p.Id == id))
        {
            Console.WriteLine($"Product with {id} already exist.");
            return;
        }

        var name = _userInput.GetValidateStringInput("Product name: ");

        if (_inventory.GetAll().Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Product with {name} already exist.");
            return;
        }

        var quantity = _userInput.GetValidateIntInput("Quantity: ");

        var price = _userInput.GetValidateDecimalInput("Price: ");

        var newProduct = new Product
        {
            Id = id,
            Name = name,
            Quantity = quantity,
            Price = price,
        };

        _inventory.GetAll().Add(newProduct);

        Console.WriteLine("Product Added!");
        Console.WriteLine($"ID: {id} | Name: {name} | Quantity: {quantity} | Price: {price:C}");
    }

    public void ShowAllProduct()
    {
        Console.Clear();

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
        Console.Clear();

        if (_userInput.IsProductEmpty())
        {
            Console.WriteLine("Product is empty.");
            return;
        }

        var id = _userInput.GetValidateStringInput("Product ID: ");

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
        Console.Clear();

        if (_userInput.IsProductEmpty())
        {
            Console.WriteLine("Product is empty.");
            return;
        }

        Console.WriteLine("Current Product:");
        ShowAllProduct();

        var id = _userInput.GetValidateStringInput("Product ID: ");

        var product = _inventory.GetAll().FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            Console.WriteLine($"Product with ID: {id} not exist.");
            return;
        }

        _inventory.GetAll().Remove(product);
        Console.WriteLine($"Product with ID: {id} was removed.");
    }

    public void UpdateQuantityProduct(Menu menu)
    {
        Console.Clear();

        if (_userInput.IsProductEmpty())
        {
            Console.WriteLine("Product is empty.");
            return;
        }

        ShowAllProduct();

        var id = _userInput.GetValidateStringInput("Product ID: ");

        var product = _inventory.GetAll().FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            Console.WriteLine($"Product with ID: {id} not exist.");
            return;
        }

        Console.WriteLine($"Selected Product: {product.Id}");
        Console.WriteLine($"Current Quantity: {product.Quantity}");
        Console.WriteLine($"Total Value: {product.TotalValue:C}");

        menu.UpdateQuantityMenu();

        var choice = _userInput.GetValidateStringInput("Choice: ");

        switch (choice)
        {
            case "1":
                var newQty = _userInput.GetValidateIntInput("Amount to update: ");
                product.Quantity = newQty;
                break;

            case "2":
                var addQty = _userInput.GetValidateIntInput("Amount to add: ");
                product.Quantity += addQty;
                break;

            case "3":
                var subtractQty = _userInput.GetValidateIntInput("Amount to subtract: ");

                if (product.Quantity - subtractQty < 0)
                {
                    Console.WriteLine("Amount cannot be negative");
                    return;
                }
                else
                {
                    product.Quantity -= subtractQty;
                    Console.WriteLine("Success: Quantity subtracted.");
                }
                break;
        }

        Console.WriteLine("Success: Quantity updated.");
        Console.WriteLine(
            $"Updated Quantity: ID: {product.Id} | Name: {product.Name} | Quantity: {product.Quantity}"
        );
        Console.WriteLine($"New Total Value: {product.TotalValue:C}");
    }
}
