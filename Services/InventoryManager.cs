public class InventoryManager
{
    private readonly ProductRepository _inventory;

    public InventoryManager(ProductRepository inventory)
    {
        _inventory = inventory;
    }
}
