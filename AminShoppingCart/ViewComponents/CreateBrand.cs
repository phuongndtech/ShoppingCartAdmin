using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AminShoppingCart.ViewComponents
{
    [ViewComponent(Name = "CreateBrand")]
    public class CreateBrand:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() => View();
    }
}
