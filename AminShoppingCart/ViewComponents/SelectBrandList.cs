using AminShoppingCart.Models.ViewModels;
using AminShoppingCart.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AminShoppingCart.ViewComponents
{
    [ViewComponent(Name = "SelectBrandList")]
    public class SelectBrandList:ViewComponent
    {

        private readonly IBrandService _service;
        private readonly IMapper _mapper;

        public SelectBrandList(IBrandService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _service.GetBrands();
            List<BrandViewModel> viewModels = _mapper.Map<List<BrandViewModel>>(items);
            return View(viewModels);
        }
    }
}
