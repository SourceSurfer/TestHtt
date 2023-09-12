using Microsoft.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

using TestHtt.Models;

namespace TestHtt.Services
{
    public class ProductCategoryService<T> : BaseFunctional<T>
    {
        /// <summary>
        /// Получение всех категорий
        /// </summary>
        /// <returns>Список категорий</returns>
        public IEnumerable<ProductCategoriesModel> GetCategories()
        {
            List<ProductCategoriesModel> products = new List<ProductCategoriesModel>();


            using var connection = new SqlConService().Connection();
            using SqlCommand command = new SqlCommand("ProductCategoryAll", connection);
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                connection?.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new ProductCategoriesModel
                    {
                        CategoryId = (int)reader["CategoryID"],
                        CategoryName = (string)reader["CategoryName"],
                        CategoryDescription = (string)reader["Description"]
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return products;
        }


        public IEnumerable<ProductCategoriesModel> Search(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
