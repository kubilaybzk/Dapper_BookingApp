using Microsoft.AspNetCore.Mvc;



namespace Dapper_Web_UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

