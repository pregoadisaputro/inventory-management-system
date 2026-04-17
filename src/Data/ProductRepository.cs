using InventoryManagement.Interfaces;
using InventoryManagement.Models;

namespace InventoryManagement.Data;

public class ProductRepository : IProductRepository
{
    private List<Product> _products = new List<Product>();

    public IReadOnlyList<Product> GetAll() => _products.ToList();

    public void Add(Product product) => _products.Add(product);

    public void Remove(Product product) => _products.Remove(product);
}
