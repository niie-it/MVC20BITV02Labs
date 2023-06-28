using Lab01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace Lab01.Controllers
{
    public class TestController : Controller
    {
        public async Task<IActionResult> AsyncTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var tm = new TestModel();
            var a = tm.AAsync();
            var b = tm.BAsync();
            var c = tm.CAsync();
            await a; await b; await c;

            sw.Stop();
            return Content($"Chạy hết {sw.ElapsedMilliseconds} ms");
        }

        public IActionResult SyncTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var tm = new TestModel();
            tm.A();
            tm.B();
            tm.C();

            sw.Stop();
            return Content($"Chạy hết {sw.Elapsed}s");
        }

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
