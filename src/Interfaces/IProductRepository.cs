using InventoryManagement.Models;

namespace InventoryManagement.Interfaces;

public interface IProductRepository
{
    IReadOnlyList<Product> GetAll();
    void Add(Product product);
    void Remove(Product product);
}
