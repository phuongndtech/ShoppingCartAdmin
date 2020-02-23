using AminShoppingCart.Models.ViewModels;
using AminShoppingCart.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AminShoppingCart.ViewComponents
{
    [ViewComponent(Name = "ProductCategoryDetail")]
    public class ProductCategoryDetail:ViewComponent
    {
        private readonly IProductCategoryService _service;
        private readonly IMapper _mapper;

        public ProductCategoryDetail(IProductCategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var items = await _service.GetProductCategoryDetail(id);
            List<ProductCategoryDetailViewModel> viewModels = _mapper.Map<List<ProductCategoryDetailViewModel>>(items);
            return View(viewModels);
        }
    }
}
