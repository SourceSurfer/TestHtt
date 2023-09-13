using Microsoft.AspNetCore.Mvc;
using TestHtt.Models;

namespace TestHtt.Controllers;

public class ProductsController : Controller
{
    private readonly IBaseService _baseService;

    private readonly IProductService _productService;

    public ProductsController(IProductService productService, IBaseService baseService)
    {
        _productService = productService;
        _baseService = baseService;
    }


    public IActionResult Index(int catId = 1)
    {
        // var list = new ProductService().GetProducts();

        return View(_productService.GetProducts());
    }

    public IActionResult SearchResult(string prodName)
    {
        //  var productService = new ProductService();
        return View("index", _productService.SearchProducts(prodName));
    }

    public IActionResult SearchForm()
    {
        return View();
    }

    public IActionResult ShowDetails(int id)
    {
        var model = _productService.GetProductById(id);
        return View(model);
    }

    public IActionResult Edit(int id)
    {
        var model = _productService.GetProductById(id);
        return View("ShowEdit", model);
    }

    public IActionResult ProcessEdit(int ProductId, string ProductName, int CategoryId,
        decimal Price, int StockQuantity, string Description)
    {
        _baseService.Update("ProductChange",
            new[] { "@ProductId", "@ProductName", "@CategoryId", "@Price", "@StockQuantity", "@Description" },
            new object[] { ProductId, ProductName, CategoryId, Price, StockQuantity, Description });
        return View("Index", _productService.GetProducts());
    }

    public IActionResult Delete(int id)
    {
        _baseService.Delete("ProductDelete", "@ProductId", id);
        return View("Index", _productService.GetProducts());
    }


    public IActionResult InputForm()
    {
        return View("InputForm");
    }

    public IActionResult ProcessCreate(string ProductName, int CategoryId,
        decimal Price, int StockQuantity, string Description)
    {
        _baseService.Insert("ProductAdd",
            new[] { "@ProdName", "@CategoryID", "@Price", "@StockQuantity", "@Description" },
            new object[] { ProductName, CategoryId, Price, StockQuantity, Description });
        return View("Index", _productService.GetProducts());
    }
}