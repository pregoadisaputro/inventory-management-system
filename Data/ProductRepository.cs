public class ProductRepository : IProductRepository
{
    private List<Product> _products = new List<Product>();

    public List<Product> GetAll() => _products;
}
