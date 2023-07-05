using Buoi04_05072023.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi04_05072023.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if(ModelState.IsValid)
            {
                //xử lý nghiệp vụ
            }
            return View();
        }
    }
}
