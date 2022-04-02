using Microsoft.AspNetCore.Mvc;
using WebApplication2.AOP;

namespace WebApplication2.Controllers
{
    public class Demo1 : Controller
    {
        // [IResourceFilterTest]                  //同步资源缓存标记方法 
        [IAnsycResourceFilterTest]               //异步资源缓存
        public IActionResult Index()
        {
            ViewBag.Date1 = DateTime.Now.ToString("yyyy-MM-dd H:mm:s:fff ");
            return View();
        }
    }
}
