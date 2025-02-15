using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Dtos.ProductDtos;
using MongoDbFoodMart.Services.ProductServices;

namespace MongoDbFoodMart.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IProductService _productService;

        public DefaultController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult UILayout()
        {
            return View();
        }

        public IActionResult AdminLayout()
        {
            return View();
        }
        
        public IActionResult ProductDetail()
        {
            return View();
        }
     
       
    }
}
