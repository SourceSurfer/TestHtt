using Microsoft.AspNetCore.Mvc;

namespace TestHtt.Controllers
{
    public class ProductCategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
