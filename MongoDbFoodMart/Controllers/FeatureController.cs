using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Dtos.FeatureDtos;
using MongoDbFoodMart.Services.FeatureServices;

namespace MongoDbFoodMart.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return RedirectToAction("FeatureSliderList");
        }

  
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return RedirectToAction("FeatureSliderList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            var value = await _featureService.GetByIDFeatureAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDto);
            return RedirectToAction("FeatureSliderList");
        }
      
    }
}
