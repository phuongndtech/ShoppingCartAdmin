using AminShoppingCart.Models.ViewModels;
using AminShoppingCart.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AminShoppingCart.ViewComponents
{
    [ViewComponent(Name = "ProductList")]
    public class ProductList:ViewComponent
    {
        private readonly IProductSerivce _product;
        private readonly IMapper _mapper;

        public ProductList(IProductSerivce product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _product.GetProducts();
            List<ProductViewModel> viewModels = _mapper.Map<List<ProductViewModel>>(items);
            return View(viewModels);
        }
    }
}