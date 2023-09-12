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
            ProductService productService = new ProductService();
            return View("index",productService.SearchProducts(prodName));
        }

        public IActionResult SearchForm()
        {
            return View();
        }
    }
}
