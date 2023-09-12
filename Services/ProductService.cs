
using System.Data;

using Microsoft.Data.SqlClient;

using TestHtt.Models;

namespace TestHtt.Services
{
    public class ProductService : IProductDataService
    {


        /// <summary>
        /// Получение продукта по его Id
        /// </summary>
        /// <param name="id">Id продукта по умолчанию 1</param>
        /// <returns></returns>
        public ProductsModel GetProductById(int id = 1)
        {
            ProductsModel product = new ProductsModel();

            using var connection = new SqlConService().Connection();
            using SqlCommand command = new SqlCommand("ProductsById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@prodId", id);
            try
            {
                connection?.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product = new ProductsModel()
                    {
                        ProductId = (int)reader["CategoryID"],
                        ProductName = (string)reader["ProductName"],
                        CategoryId = (int)reader["CategoryID"],
                        Price = (decimal)reader["Price"],
                        StockQuantity = (int)reader["StockQuantity"],
                        Description = (string)reader["Description"]
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return product;
        }

        /// <summary>
        /// Возвращает все продукты
        /// </summary>
        /// <returns>Продукты</returns>
        public IEnumerable<ProductsModel> GetProducts()
        {
            List<ProductsModel> products = new List<ProductsModel>();

            using (
                var connection = new SqlConService().Connection())
            {

                using (SqlCommand command = new SqlCommand("ProductsAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection?.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            products.Add(
                                new ProductsModel()
                                {
                                    ProductId = (int)reader["ProductID"],
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

        public int Delete(ProductsModel model)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductsModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Поиск похожего по названию продукта
        /// </summary>
        /// <param name="searchTerm">Наименование продукта</param>
        /// <returns></returns>
        public IEnumerable<ProductsModel> SearchProducts(string searchTerm)
        {
            List<ProductsModel> products = new List<ProductsModel>();

            using var connection = new SqlConService().Connection();
            using SqlCommand command = new SqlCommand("ProductSearch", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@productName", '%' + searchTerm);
            try
            {
                connection?.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(
                        new ProductsModel()
                        {
                            ProductId = (int)reader["ProductID"],
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

            return products;
        }

       

        public int Update(ProductsModel model)
        {
            throw new NotImplementedException();
        }
    }
}
