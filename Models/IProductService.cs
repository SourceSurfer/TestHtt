namespace TestHtt.Models;

public interface IProductService
{
    IEnumerable<Products> GetProducts();
    IEnumerable<Products> SearchProducts(string searchTerm);
    Products GetProductById(int id);
}