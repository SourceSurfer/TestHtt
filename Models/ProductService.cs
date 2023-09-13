using System.Data;
using Microsoft.Data.SqlClient;
using TestHtt.Services;

namespace TestHtt.Models;

public class ProductService : BaseFunctional, IProductService
{
    /// <summary>
    ///     Получение продукта по его Id
    /// </summary>
    /// <param name="id">Id продукта по умолчанию 1</param>
    /// <returns></returns>
    public Products GetProductById(int id = 1)
    {
        var product = new Products();

        using var connection = new SqlConService().Connection();
        using var command = new SqlCommand("ProductsById", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@prodId", id);
        try
        {
            connection?.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
                product = new Products
                {
                    ProductId = (int)reader["ProductID"],
                    ProductName = (string)reader["ProductName"],
                    CategoryId = (int)reader["CategoryID"],
                    Price = (decimal)reader["Price"],
                    StockQuantity = (int)reader["StockQuantity"],
                    Description = (string)reader["Description"]
                };
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return product;
    }

    /// <summary>
    ///     Возвращает все продукты
    /// </summary>
    /// <returns>Продукты</returns>
    public IEnumerable<Products> GetProducts()
    {
        var products = new List<Products>();

        using (
            var connection = new SqlConService().Connection())
        {
            using (var command = new SqlCommand("ProductsAll", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection?.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        products.Add(
                            new Products
                            {
                                ProductId = (int)reader["ProductID"],
                                ProductName = (string)reader["ProductName"],
                                CategoryId = (int)reader["CategoryID"],
                                Price = (decimal)reader["Price"],
                                StockQuantity = (int)reader["StockQuantity"],
                                Description = (string)reader["Description"]
                            });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    products.Add(new Products
                    {
                        ProductName = e.Message
                    });
                }
            }
        }

        return products;
    }

    /// <summary>
    ///     Поиск похожего по названию продукта
    /// </summary>
    /// <param name="searchTerm">Наименование продукта</param>
    /// <returns></returns>
    public IEnumerable<Products> SearchProducts(string searchTerm)
    {
        var products = new List<Products>();

        using var connection = new SqlConService().Connection();
        using var command = new SqlCommand("ProductSearch", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@productName", '%' + searchTerm);
        try
        {
            connection?.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
                products.Add(
                    new Products
                    {
                        ProductId = (int)reader["ProductID"],
                        ProductName = (string)reader["ProductName"],
                        CategoryId = (int)reader["CategoryID"],
                        Price = (decimal)reader["Price"],
                        StockQuantity = (int)reader["StockQuantity"],
                        Description = (string)reader["Description"]
                    });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return products;
    }
}