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
        if (_inventory.GetAll().Count == 0)
        {
            Console.WriteLine("Product is empty.");
            return;
        }
        else
        {
            foreach (var product in _inventory.GetAll())
            {
                Console.WriteLine(
                    $"ID: {product.Id} | Name: {product.Name} | Quantity: {product.Quantity} | Price: {product.Price:C}"
                );
            }
        }
    }

    public void FindProduct() { }

    public void DeleteProduct() { }
}
