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
    [ViewComponent(Name = "BrandDetail")]
    public class BrandDetail:ViewComponent
    {

        private readonly IBrandService _service;
        private readonly IMapper _mapper;

        public BrandDetail(IBrandService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var items = await _service.GetBrandDetail(id);
            BrandViewModel viewModels = _mapper.Map<BrandViewModel>(items);
            return View(viewModels);
        }
    }
}
