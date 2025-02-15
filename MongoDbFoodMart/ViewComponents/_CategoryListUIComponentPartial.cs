using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.CategoryServices;

namespace MongoDbFoodMart.ViewComponents
{
    public class _CategoryListUIComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoryListUIComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
