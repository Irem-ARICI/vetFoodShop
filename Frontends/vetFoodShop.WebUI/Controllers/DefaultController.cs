using Microsoft.AspNetCore.Mvc;

namespace vetFoodShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
