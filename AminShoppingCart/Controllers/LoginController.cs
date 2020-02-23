using AminShoppingCart.DTOs.RequestDTOs;
using AminShoppingCart.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AminShoppingCart.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Save(UserRequestDTO userRequest)
        {
            _userService.CreateUser(userRequest);
            return RedirectToAction("Index");
        }
    }
}