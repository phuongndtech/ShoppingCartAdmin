using AminShoppingCart.DTOs.RequestDTOs;
using AminShoppingCart.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AminShoppingCart.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _service;
        public BrandController(IBrandService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetListVC()
        {
            return ViewComponent("BrandList");
        }

        public IActionResult GetDetailVC(int id)
        {
            return ViewComponent("BrandDetail", new { id = id });
        }

        public IActionResult CreateVC()
        {
            return ViewComponent("CreateBrand");
        }

        public IActionResult DeleteVC(int id)
        {
            _service.DeleteBrand(id);
            return RedirectToAction("Index");
        }

        public IActionResult Save(BrandRequestDTO request)
        {
            if (request.Id > 0)
            {
                _service.UpdateBrand(request);
            }
            else
            {
                _service.CreateBrand(request);
            }

            return RedirectToAction("Index");
        }
    }
}