using AminShoppingCart.Models.ViewModels;
using AminShoppingCart.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AminShoppingCart.ViewComponents
{

    [ViewComponent(Name = "ProductDetail")]
    public class ProductDetail : ViewComponent
    {
        private readonly IProductSerivce _product;
        private readonly IMapper _mapper;

        public ProductDetail(IProductSerivce product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var items = await _product.GetProductById(id);
            ProductViewModel viewModels = _mapper.Map<ProductViewModel>(items);
            return View(viewModels);
        }
    }
}
