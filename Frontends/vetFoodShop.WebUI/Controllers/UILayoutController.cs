using Microsoft.AspNetCore.Mvc;

namespace vetFoodShop.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
