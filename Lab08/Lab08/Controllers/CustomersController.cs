using Lab08.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab08.Controllers
{
	public class CustomersController : Controller
	{
		private readonly CarDealerContext _context;

		public CustomersController(CarDealerContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}


		#region L1.3.1.1
		[HttpGet("/customers/all/ascending")]
		public IActionResult GetAllCustomerOrderAscending()
		{
			var data = _context.Customers
				.OrderBy(c => c.BirthDate)
				.ThenByDescending(c => c.IsYoungDriver)
				.ToList();

			return Json(data);
		}

		[HttpGet("/customers/all/descending")]
		public IActionResult GetAllCustomerOrderDescending()
		{
			var data = _context.Customers
				.OrderByDescending(c => c.BirthDate)
				.ThenByDescending(c => c.IsYoungDriver)
				.ToList();

			return Json(data);
		}
		#endregion

		#region L1.3.1.2
		[HttpPost("/cars/{branch}")]
		public IActionResult GetCarsByMake(string branch)
		{
			var data = _context.Cars
				.Where(c => c.Make == branch)
				.OrderBy(c => c.Model)
				.ThenByDescending(c => c.TravelledDistance)
				.ToList();

			return View(data);
		}
		#endregion

		#region L1.3.1.3
		[HttpGet("/suppliers/local")]
		public IActionResult GetLocalSuppliers()
		{
			var data = _context.Suppliers
				.Where(s => !s.IsImporter) //IsImporter = false
				.ToList();

			return Json(data);
		}

		[HttpGet("/suppliers/importers")]
		public IActionResult GetImportersSuppliers()
		{
			var data = _context.Suppliers
				.Where(s => s.IsImporter) //IsImporter = true
				.ToList();

			return Json(data);
		}
		#endregion

		#region L1.3.1.4
		[HttpGet("/cars/{id}/parts")]
		public IActionResult actionResult(int id)
		{
			var data = _context.Cars
				.Include(c => c.Parts)
				.Where(c => c.Id == id)
				.Select(c => new {
					c.Make,
					c.Model,
					c.TravelledDistance,
					Parts = c.Parts.Select(p => new
					{
						p.Name, p.Price
					}).ToList()
				})
				.ToList();

			return Json(data);
		}
		#endregion
	}
}
