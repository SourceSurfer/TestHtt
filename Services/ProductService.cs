using System.Data;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TestHtt.Models;

namespace TestHtt.Services
{
    public class ProductService
    {
        /// <summary>
        /// Возвращает продукты
        /// </summary>
        /// <param name="catrgoryId">ID Категории продуктов</param>
        /// <returns></returns>
        public IEnumerable<ProductsModel> GetProducts(int catrgoryId)
        {
            List<ProductsModel> products = new List<ProductsModel>();

            SqlConService usersDAO = new SqlConService();

            using (SqlConnection? connection = usersDAO.Connection())
            {
                using (SqlCommand command = new SqlCommand("ProductsAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryId", catrgoryId);
                    try
                    {
                        connection?.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            products.Add(
                                new ProductsModel()
                                {
                                    ProductId = (int)reader["CategoryID"],
                                    ProductName = (string)reader["ProductName"],
                                    CategoryId = (int)reader["CategoryID"],
                                    Price = (decimal)reader["Price"],
                                    StockQuantity = (int)reader["StockQuantity"],
                                    Description = (string)reader["Description"]
                                });
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                
            }

            return products;
        }
    }
}
