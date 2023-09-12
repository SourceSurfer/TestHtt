using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestHtt.Models
{
    public class ProductsModel
    {
        [DisplayName("ProductId")]
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Category id")]
        public int CategoryId { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [DisplayName("StockQuantity")]
        public int StockQuantity { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }

       


    }
}
