using System.Text.Json;
using InventoryManagement.Interfaces;
using InventoryManagement.Models;

namespace InventoryManagement.Data;

public class JsonProductRepository : IProductRepository
{
    private readonly string _storageFolder = "Storage";
    private readonly string _jsonFilePath;
    private readonly string _logFilePath;
    private List<Product> _products = new();

    public JsonProductRepository()
    {
        _jsonFilePath = Path.Combine(_storageFolder, "products.json");
        _logFilePath = Path.Combine(_storageFolder, "activity.txt");

        if (!Directory.Exists(_storageFolder))
        {
            Directory.CreateDirectory(_storageFolder);
        }

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
        catch (JsonException ex)
        {
            Console.WriteLine($"Error, JSON file is corrupted: {ex.Message}");
            Console.WriteLine($"Please check Storage/products.json for syntax errors.");

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
        if (File.Exists(_logFilePath))
        {
            long fileSize = new FileInfo(_logFilePath).Length;

            if (fileSize > 100 * 1024)
            {
                File.WriteAllText(_logFilePath, "LOG CLEARED DUE TO SIZE\n");
            }
        }

        string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";
        File.AppendAllText(_logFilePath, logEntry);
    }
}
