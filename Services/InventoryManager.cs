public class InventoryManager : IInventoryManager
{
    private readonly ProductRepository _inventory;

    public InventoryManager(ProductRepository inventory)
    {
        _inventory = inventory;
    }

    public void AddProduct() { }

    public void ShowAllProduct() { }

    public void FindProduct() { }

    public void DeleteProduct() { }
}
