using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.SellingServices;

namespace MongoDbFoodMart.ViewComponents
{
    public class _SellingUIComponentPartial : ViewComponent
    {
        private readonly ISellingService _sellingService;

        public _SellingUIComponentPartial(ISellingService sellingService)
        {
            _sellingService = sellingService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _sellingService.GetAllSellingsWithProductAsync();
            return View(values);
        }
    }
}
