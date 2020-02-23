using AminShoppingCart.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AminShoppingCart.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserListVC()
        {
            return ViewComponent("UserList");
        }

        public IActionResult UserDetailVC(int id)
        {
            return ViewComponent("UserDetail", new { id = id });
        }

        public IActionResult CreateUserVC()
        {
            return ViewComponent("CreateUser");
        }

        public IActionResult UpdateUserVC()
        {
            return ViewComponent("UpdateUser");
        }

        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}