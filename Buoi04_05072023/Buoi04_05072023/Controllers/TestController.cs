using Buoi04_05072023.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi04_05072023.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EmployeeInfo emp)
        {
            if (ModelState.IsValid)
            {
                //thành công ==> lưu DB
                ViewBag.Message = "Hết lỗi";
            }
            else
            {
                ModelState.AddModelError("info", "Còn lỗi");
            }
            return View();
        }
    }
}
