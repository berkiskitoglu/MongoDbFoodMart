using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Dtos.ProductDtos;
using MongoDbFoodMart.Services.ProductServices;

namespace MongoDbFoodMart.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService categoryService)
        {
            _productService = categoryService;
        }

        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductWithCategoryAsync();
            return View(values);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> DeleteProduct(string categoryID)
        {
            await _productService.DeleteProductAsync(categoryID);
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string categoryID)
        {
            var value = await _productService.GetByIDProductAsync(categoryID);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("ProductList");
        }
    }
}
