public interface IProductRepository
{
    List<Product> GetAll();
    void Add(Product product);
    void Remove(Product product);
}
