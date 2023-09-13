using System.Data;
using Microsoft.Data.SqlClient;
using TestHtt.Services;

namespace TestHtt.Models;

public class CategoryService : BaseFunctional, ICategoryService
{
    /// <summary>
    ///     Получение всех категорий
    /// </summary>
    /// <returns>Список категорий</returns>
    public IEnumerable<Categories> GetCategories()
    {
        var products = new List<Categories>();


        using var connection = new SqlConService().Connection();
        using var command = new SqlCommand("ProductCategoryAll", connection);
        command.CommandType = CommandType.StoredProcedure;

        try
        {
            connection?.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
                products.Add(new Categories
                {
                    CategoryId = (int)reader["CategoryID"],
                    CategoryName = (string)reader["CategoryName"],
                    CategoryDescription = (string)reader["Description"]
                });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return products;
    }

    public IEnumerable<Categories> SearchCategories(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public Categories? GetProductCategoryById(int id)
    {
        Categories? categories = null;

        using var connection = new SqlConService().Connection();
        using var command = new SqlCommand("ProductCategoryById", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@catId", id);
        try
        {
            connection?.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
                categories = new Categories
                {
                    CategoryId = (int)reader["CategoryID"],
                    CategoryName = (string)reader["CategoryName"],
                    CategoryDescription = (string)reader["Description"]
                };
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return categories;
    }
}