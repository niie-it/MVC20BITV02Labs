using Lab01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Lab01.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        const string JSON_FILE = "Student.json";
        const string TEXT_FILE = "Student.txt";

        [HttpPost]
        public IActionResult Manage(Student sv, string Save)
        {
            if (Save == "Save to JSON file")
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", JSON_FILE);

                var jsonContent = JsonSerializer.Serialize(sv);

                System.IO.File.WriteAllText(filePath, jsonContent);
            }
            return View("Index", sv);
        }

        public IActionResult ReadData(string filetype)
        {
            var sv = new Student();

            if (filetype == "JSON")
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", JSON_FILE);
                var fileContent = System.IO.File.ReadAllText(filePath);

                sv = JsonSerializer.Deserialize<Student>(fileContent);
            }

            return View("Index", sv);
        }
    }
}
