using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Dtos.SellingDtos;
using MongoDbFoodMart.Services.SellingServices;

namespace MongoDbFoodMart.Controllers
{
    public class SellingController : Controller
    {
        private readonly ISellingService _sellingService;

        public SellingController(ISellingService sellingService)
        {
            _sellingService = sellingService;
        }

      

        public async Task<IActionResult> SellingList()
        {
            var values = await _sellingService.GetAllSellingsWithProductAsync();       
            return View(values);
        }

        public IActionResult CreateSelling()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSelling(CreateSellingDto createSellingDto)
        {
            createSellingDto.SellingDate = DateTime.Now;
            await _sellingService.CreateSellingAsync(createSellingDto);
            return RedirectToAction("SellingList");
        }
        public async Task<IActionResult> DeleteSelling(string id)
        {
            await _sellingService.DeleteSellingAsync(id);
            return RedirectToAction("SellingList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSelling(string id)
        {
            var value = await _sellingService.GetByIDSellingAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSelling(UpdateSellingDto updateSellingDto)
        {
            updateSellingDto.SellingDate = DateTime.Now;
            await _sellingService.UpdateSellingAsync(updateSellingDto);
            return RedirectToAction("SellingList");
        }
    }
}
