using TestHtt.Models;

namespace TestHtt.Services
{
    public interface IProductDataService
    {
        IEnumerable<ProductsModel> GetProducts();
        IEnumerable<ProductsModel> SearchProducts(string searchTerm);
        ProductsModel GetProductById(int id);
        int Insert(ProductsModel model);
        int Update(ProductsModel model);
        int Delete(ProductsModel model);
    }
}
