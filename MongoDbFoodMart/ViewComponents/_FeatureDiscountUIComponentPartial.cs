using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.DiscountServices;

namespace MongoDbFoodMart.ViewComponents
{
    public class _FeatureDiscountUIComponentPartial : ViewComponent
    {
        private readonly IDiscountService _discountService;

        public _FeatureDiscountUIComponentPartial(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _discountService.GetAllDiscountAsync();
            return View(values);
        }
    }
}
