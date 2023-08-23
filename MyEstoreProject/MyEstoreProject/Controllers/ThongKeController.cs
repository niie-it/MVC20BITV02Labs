using Microsoft.AspNetCore.Mvc;
using MyEstoreProject.Data;

namespace MyEstoreProject.Controllers
{
    public class ThongKeController : Controller
    {
        private readonly MyeStoreContext _ctx;

        public ThongKeController(MyeStoreContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult ThongKe()
        {
            var data = _ctx.ChiTietHds
                .GroupBy(cthd => new
                {
                    cthd.MaHhNavigation.MaLoaiNavigation.TenLoai,
                    cthd.MaHhNavigation.MaNccNavigation.TenCongTy
                })
                .Select(cthd => new
                {
                    cthd.Key.TenLoai,
                    cthd.Key.TenCongTy,
                    TongGiaTri = cthd.Sum(ct => ct.SoLuong * ct.DonGia),
                    GiaNN = cthd.Min(ct => ct.DonGia),
                    GiaLN = cthd.Max(ct => ct.DonGia),
                });
            return Json(data);
        }
    }
}
