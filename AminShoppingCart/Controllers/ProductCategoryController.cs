using AminShoppingCart.DTOs.RequestDTOs;
using AminShoppingCart.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AminShoppingCart.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _service;
        public ProductCategoryController(IProductCategoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetListVC()
        {
            return ViewComponent("ProductCategoryList");
        }

        public IActionResult GetDetailVC(int id)
        {
            return ViewComponent("ProductCategoryDetail", new { id = id });
        }

        public IActionResult CreateVC()
        {
            return ViewComponent("CreateProductCategory");
        }

        public IActionResult DeleteVC(ProductCategoryRequestDTO request)
        {
            _service.DeleteProductCategory(request);
            return RedirectToAction("Index");
        }

        public IActionResult CreateProductCategory(ProductCategoryRequestDTO request)
        {
            _service.CreateProductCategory(request);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateProductCategory(ProductCategoryRequestDTO request)
        {
            _service.UpdateProductCategory(request);
            return RedirectToAction("Index");
        }
    }
}