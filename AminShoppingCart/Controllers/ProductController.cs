using AminShoppingCart.DTOs.RequestDTOs;
using AminShoppingCart.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AminShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductSerivce _product;
        public IUserService _userService;
        public ProductController(IProductSerivce product, IUserService userService)
        {
            _product = product;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductListVC()
        {
            return ViewComponent("ProductList");
        }

        public IActionResult ProductDetailVC(int id)
        {
            return ViewComponent("ProductDetail", new { id = id });
        }

        public IActionResult CreateProductVC()
        {
            return ViewComponent("CreateProduct");
        }
        public IActionResult SelectBrandListVC()
        {
            return ViewComponent("SelectBrandList");
        }
        public IActionResult DeleteProdcuctVC(int id)
        {
            _product.DeleteProduct(id);
            return RedirectToAction("Index");
        }
       
        public IActionResult SaveProduct(ProductRequestDTO productRequest)
        {
            if(productRequest.ProductId > 0)
            {
                _product.UpdateProduct(productRequest);
            }
            else
            {
                _product.CreateProduct(productRequest);
            }
         
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Authenticate(UserRequestDTO userRequest)
        {
            if (ModelState.IsValid)
            {
                var login = await _userService.Login(userRequest);
                if (!login)
                {
                    throw new Exception("Login fail");
                }
            }
            return RedirectToAction("Index");
        }
    }
}