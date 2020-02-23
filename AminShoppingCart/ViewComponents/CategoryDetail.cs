using AminShoppingCart.Models.ViewModels;
using AminShoppingCart.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AminShoppingCart.ViewComponents
{
    [ViewComponent(Name = "CategoryDetail")]
    public class CategoryDetail:ViewComponent
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoryDetail(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var items = await _service.GetCategoryDetail(id);
            CategoryViewModel viewModels = _mapper.Map<CategoryViewModel>(items);
            return View(viewModels);
        }
    }
}