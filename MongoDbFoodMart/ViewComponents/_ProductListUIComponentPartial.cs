using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.ProductServices;

namespace MongoDbFoodMart.ViewComponents
{
    public class _ProductListUIComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListUIComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductWithCategoryAsync();
            return View(values);
        }
    }
}
