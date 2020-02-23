using AminShoppingCart.Models.ViewModels;
using AminShoppingCart.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AminShoppingCart.ViewComponents
{
    [ViewComponent(Name = "UpdateUser")]
    public class UserDetail:ViewComponent
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserDetail(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var items = await _userService.GetUserDetail(Id);
            UserViewModel viewModels = _mapper.Map<UserViewModel>(items);
            return View(viewModels);
        }
    }
}
