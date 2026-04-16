public class Menu : IMenu
{
    private readonly InventoryManager _manager;

    public Menu(InventoryManager manager)
    {
        _manager = manager;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. Show All Product");
        Console.WriteLine("3. Find Product");
        Console.WriteLine("4. Update Product Quantity");
        Console.WriteLine("5. Delete Product");
        Console.WriteLine("6. Exit");
    }

    public void UpdateQuantityMenu()
    {
        Console.WriteLine("1. Update Quantity");
        Console.WriteLine("2. Add Quantity");
        Console.WriteLine("3. Subtract Quantity");
    }

    public void UserMenuChoice()
    {
        var isRunning = true;

        while (isRunning)
        {
            DisplayMenu();

            Console.WriteLine("Select an option (1-6): ");
            var choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    _manager.AddProduct();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "2":
                    _manager.ShowAllProduct();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "3":
                    _manager.FindProduct();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "4":
                    _manager.UpdateQuantityProduct(this);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "5":
                    _manager.DeleteProduct();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "6":
                    isRunning = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
