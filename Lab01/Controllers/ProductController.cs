using Lab01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab01.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
        {
            new Product{Id = 1, Name = "IPhone 14", Price = 27999},
            new Product{Id = 2, Name = "IPhone 15", Price = 29999}
        };

        public IActionResult Index()
        {
            // gửi mảng sản phẩm qua View để hiển thị
            return View(products);
        }
    }
}
