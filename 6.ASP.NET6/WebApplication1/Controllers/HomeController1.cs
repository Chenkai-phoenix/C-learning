using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {

            ViewBag.User1 = "LL";
            ViewData["User2"] = "CK";
            TempData["User3"] = "LJ";
            HttpContext.Session.SetString("User4","ZJ"); //Session 需要注册
            object User5 = "JW";                         //View(object model)
            return View(User5); 
        }
    }
}
