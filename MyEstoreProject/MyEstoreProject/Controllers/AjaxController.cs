using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEstoreProject.Data;
using MyEstoreProject.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace MyEstoreProject.Controllers
{
    public class AjaxController : Controller
    {
        private readonly MyeStoreContext _context;

        public AjaxController(MyeStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ServerTime()
        {
            return Content(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string? keyword)
        {
            var dsHangHoa = _context.HangHoas.Include(hh => hh.MaLoaiNavigation).AsQueryable();
            if (keyword != null)
            {
                dsHangHoa = dsHangHoa.Where(hh => hh.TenHh.Contains(keyword));
            }

            var data = dsHangHoa.Select(hh => new KetQuaTimKiemVM
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                DonGia = hh.DonGia.Value,
                NgaySX = hh.NgaySx,
                Loai = hh.MaLoaiNavigation.TenLoai
            }).ToList();
            return PartialView("TimKiemPartial", data);
        }


        [HttpGet]
        public IActionResult TimKiem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TimKiem(string? name, double? fromPrice, double? toPrice)
        {
            var dsHangHoa = _context.HangHoas.Include(hh => hh.MaLoaiNavigation).AsQueryable();
            if (name != null)
            {
                dsHangHoa = dsHangHoa.Where(hh => hh.TenHh.Contains(name));
            }
            if (fromPrice != null)
            {
                dsHangHoa = dsHangHoa.Where(hh => hh.DonGia.Value >= fromPrice);
            }
            if (toPrice != null)
            {
                dsHangHoa = dsHangHoa.Where(hh => hh.DonGia.Value <= toPrice);
            }
            var data = dsHangHoa.Select(hh => new KetQuaTimKiemVM
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                DonGia = hh.DonGia.Value,
                NgaySX = hh.NgaySx,
                Loai = hh.MaLoaiNavigation.TenLoai
            }).ToList();
            return PartialView("TimKiemPartial", data);
        }
    }
}
