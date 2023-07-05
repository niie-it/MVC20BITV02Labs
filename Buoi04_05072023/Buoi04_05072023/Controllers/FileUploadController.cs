using Microsoft.AspNetCore.Mvc;

namespace Buoi04_05072023.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile myfile)
        {
            if (myfile != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", myfile.FileName);
                using(var file = new FileStream(filePath, FileMode.CreateNew))
                {
                    myfile.CopyTo(file);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UploadFiles(List<IFormFile> myfiles)
        {
            if (myfiles != null)
            {
                foreach(var myfile in myfiles)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", myfile.FileName);
                    using (var file = new FileStream(filePath, FileMode.CreateNew))
                    {
                        myfile.CopyTo(file);
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}
