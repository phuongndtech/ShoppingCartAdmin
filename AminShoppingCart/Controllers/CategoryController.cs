using AminShoppingCart.DTOs.RequestDTOs;
using AminShoppingCart.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AminShoppingCart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetListVC()
        {
            return ViewComponent("CategoryList");
        }

        public IActionResult GetDetailVC(int id)
        {
            return ViewComponent("CategoryDetail", new { id = id });
        }

        public IActionResult CreateVC()
        {
            return ViewComponent("CreateCategory");
        }

        public IActionResult DeleteVC(int id)
        {
            _service.DeleteCategory(id);
            return RedirectToAction("Index");
        }

        public IActionResult Save(CategoryRequestDTO request)
        {
            if (request.Id > 0)
            {
                _service.UpdateCategory(request);
            }
            else
            {
                _service.CreateCategory(request);
            }

            return RedirectToAction("Index");
        }
    }
}