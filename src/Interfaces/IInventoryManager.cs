public interface IInventoryManager
{
    bool IsProductEmpty();

    void AddProduct();
    void ShowAllProduct();
    void FindProduct();
    void DeleteProduct();
    void UpdateQuantityProduct();
}
