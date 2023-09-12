using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using TestHtt.Models;
using TestHtt.Services;

namespace TestHtt.Controllers
{
    public class ProductsController : Controller
    {
        /// <summary>
        /// Списко всех продуктов
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index(int catId = 1)
        {
            var list = new ProductService().GetProducts();

            return View(list);
        }



        public IActionResult SearchResult(string prodName)
        {
            var productService = new ProductService();
            return View("index", productService.SearchProducts(prodName));
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult ShowDetails(int id)
        {
            var products = new ProductService();
            ProductsModel model = products.GetProductById(id);
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var products = new ProductService();
            ProductsModel model = products.GetProductById(id);
            return View("ShowEdit", model);
        }

        public IActionResult ProcessEdit(int ProductId, string ProductName, int CategoryId,
            decimal Price, int StockQuantity, string Description)
        {
            var products = new ProductService();
            products.Update("ProductChange",
                new[] { "@ProductId", "@ProductName", "@CategoryId", "@Price", "@StockQuantity", "@Description" },
                new object[] { ProductId, ProductName, CategoryId, Price, StockQuantity, Description });
            return View("Index", products.GetProducts());
        }
        public IActionResult Delete(int id)
        {
            var products = new ProductService();
            products.Delete("ProductDelete", "@ProductId", id);
            return View("Index", products.GetProducts());
        }


        public IActionResult InputForm()
        {
            return View("InputForm"); 
        }

        public IActionResult ProcessCreate( string ProductName, int CategoryId,
            decimal Price, int StockQuantity, string Description)
        {
            var products = new ProductService();
            products.Insert("ProductAdd",
                new[] { "@ProdName", "@CategoryID", "@Price", "@StockQuantity", "@Description" },
                new object[] { ProductName, CategoryId, Price, StockQuantity, Description });
            return View("Index", products.GetProducts());
        }
    }
}
