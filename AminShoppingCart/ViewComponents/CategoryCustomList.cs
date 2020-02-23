using AminShoppingCart.Models.ViewModels;
using AminShoppingCart.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AminShoppingCart.ViewComponents
{
    [ViewComponent(Name = "CategoryCustomList")]
    public class CategoryCustomList : ViewComponent
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoryCustomList(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _service.GetCategories();
            List<CategoryViewModel> viewModels = _mapper.Map<List<CategoryViewModel>>(items);
            return View(viewModels);
        }
    }
}
