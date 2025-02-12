using Microsoft.AspNetCore.Mvc;

namespace MongoDbFoodMart.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult UILayout()
        {
            return View();
        }

        public IActionResult AdminLayout()
        {
            return View();
        }
  
    }
}
