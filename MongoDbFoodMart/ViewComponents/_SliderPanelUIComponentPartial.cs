using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.FeatureServices;

namespace MongoDbFoodMart.ViewComponents
{
    public class _SliderPanelUIComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _SliderPanelUIComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }
    }
}
