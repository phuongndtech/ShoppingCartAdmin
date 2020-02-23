using AminShoppingCart.Models.ViewModels;
using AminShoppingCart.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AminShoppingCart.ViewComponents
{

    [ViewComponent(Name = "UserList")]
    public class UserList:ViewComponent
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserList(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _userService.GetUserList();
            List<UserViewModel> viewModels = _mapper.Map<List<UserViewModel>>(items);
            return View(viewModels);
        }
    }
}
