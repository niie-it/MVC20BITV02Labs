using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Lab01.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Demo(int type = 1)
        {
            switch (type)
            {
                case 1: return Content("STRING RESPONSE");
                case 2: return Json(new
                {
                    ClassName = "20BITV02",
                    Count = 29
                });
                case 3:
                    return Redirect("/Home/Privacy");
                case 4:
                    //return RedirectToAction(actionName: "index", controllerName: "Home");
                    return RedirectToAction("Index", "Home");
                default: return Ok(HttpStatusCode.NotFound);
            }
            
        }
    }
}
