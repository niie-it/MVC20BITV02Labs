using Microsoft.AspNetCore.Mvc;

namespace Lab01.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(double SoHang01, double SoHang02, string PhepToan)
        {
            double giaTri = 0;
            switch(PhepToan)
            {
                case "+": giaTri = SoHang01 + SoHang02; break;
                case "-": giaTri = SoHang01 - SoHang02; break;
                case "*": giaTri = SoHang01 * SoHang02; break;
                case "/": giaTri = SoHang01 / SoHang02; break;
                case "^": giaTri = Math.Pow(SoHang01, SoHang02); break;
                case "%": giaTri = SoHang01 % SoHang02; break;
            }

            ViewBag.GiaTri = giaTri;
            ViewBag.PhepToan = PhepToan;
            ViewBag.SoHang01 = SoHang01;
            ViewBag.SoHang02 = SoHang02;

            return View("Index");
        }
    }
}
