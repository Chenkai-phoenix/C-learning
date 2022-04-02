using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController2 : Controller
    {
        private readonly ILogger<HomeController2> _ilogger;
        private readonly ILoggerFactory _loggerFactory;
        public HomeController2(ILogger<HomeController2> Ilogger, ILoggerFactory LoggerFactory)
        {
            this._ilogger = Ilogger;
            this._ilogger.LogInformation("{0}被构造了。。Ilogger1", this.GetType().Name);

            //使用工厂创建logger
            this._loggerFactory = LoggerFactory;
            ILogger<HomeController2> Ilogger2 = this._loggerFactory.CreateLogger<HomeController2>();
            Ilogger2.LogInformation("{0}被构造了。。LoggerFactory---Ilogger2", this.GetType().Name);
        }
        public IActionResult Index()
        {
          
            ILogger<HomeController2> Ilogger3 = this._loggerFactory.CreateLogger<HomeController2>();
            Ilogger3.LogInformation("{0}被执行了。。LoggerFactory---Ilogger3", this.GetType().Name);

            this._ilogger.LogInformation("Index被执行了。。");

            return View();
        }
    }
}
