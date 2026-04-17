using System.Text.Json;
using InventoryManagement.Interfaces;
using InventoryManagement.Models;

namespace InventoryManagement.Data;

public class JsonProductRepository : IProductRepository
{
    private readonly string _jsonFilePath = "products.json";
    private readonly string _logFilePath = "activity.txt";
    private List<Product> _products;

    public JsonProductRepository()
    {
        _products = LoadFromFile();
    }

    public IReadOnlyList<Product> GetAll() => _products.ToList();

    public void Add(Product product)
    {
        _products.Add(product);
        SaveToFile();
        LogActivity($"Added: {product.Name} | ID: {product.Id}");
    }

    public void Remove(Product product)
    {
        _products.Remove(product);
        SaveToFile();
        LogActivity($"Removed: {product.Name} | ID: {product.Id}");
    }

    private List<Product> LoadFromFile()
    {
        if (!File.Exists(_jsonFilePath))
            return new List<Product>();

        try
        {
            string json = File.ReadAllText(_jsonFilePath);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }
        catch
        {
            return new List<Product>();
        }
    }

    private void SaveToFile()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(_products, options);
        File.WriteAllText(_jsonFilePath, json);
    }

    private void LogActivity(string message)
    {
        string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";
        File.AppendAllText(_logFilePath, logEntry);
    }
}
