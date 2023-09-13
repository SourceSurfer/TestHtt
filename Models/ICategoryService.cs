namespace TestHtt.Models;

public interface ICategoryService
{
    public IEnumerable<Categories> GetCategories();
    public IEnumerable<Categories> SearchCategories(string searchTerm);
    public Categories? GetProductCategoryById(int id);
}