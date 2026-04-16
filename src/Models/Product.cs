namespace InventoryManagement.Models;

public class Product
{
    public required string Id { get; init; }
    public required string Name { get; set; }
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }

    public decimal TotalValue => Quantity * Price;
}
