using Microsoft.AspNetCore.Mvc;
using TestHtt.Models;

namespace TestHtt.Controllers;

public class CategoriesController : Controller
{
    private readonly IBaseService _baseService;
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService, IBaseService baseService)
    {
        _categoryService = categoryService;
        _baseService = baseService;
    }

    public IActionResult Index()
    {
        return View(_categoryService.GetCategories());
    }

    public IActionResult EditResult(int CategoryId, string CategoryName, string CategoryDescription)
    {
        _baseService.Update("ProductCategoryUpdate",
            new[] { "@value1", "@value2", "@position" },
            new object[] { CategoryName, CategoryDescription, CategoryId });

        return View("Index", _categoryService.GetCategories());
    }

    public IActionResult EditForm(int id)
    {
        var model = _categoryService.GetProductCategoryById(id);
        return View(model);
    }

    public IActionResult Delete(int id)
    {
        _baseService.Delete("ProductCategoryDelete", "@CategoryID", id);
        return View("Index", _categoryService.GetCategories());
    }
}