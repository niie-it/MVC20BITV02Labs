using EFCoreLab.Data;
using EFCoreLab.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreLab.Controllers
{
	public class SuppilersController : Controller
	{
		private readonly MVC_NIIE_LabContext _context;

		public SuppilersController(MVC_NIIE_LabContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var data = _context.Suppliers != null ? _context.Suppliers.ToList() : new List<Supplier>();
			return View(data);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Supplier model, IFormFile FileLogo)
		{
			try
			{
				if (FileLogo != null)
				{
					//upload và cập nhật field Logo
					model.Logo = MyTool.UploadImageToFolder(FileLogo, "Suppliers");
				}
				_context.Add(model);
				_context.SaveChanges();

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return View();
			}
		}

		[HttpGet]
		public IActionResult Edit(string id)
		{
			var existedSupplier = _context.Suppliers.SingleOrDefault(x => x.Id == id);
			if (existedSupplier != null)
			{
				return View(existedSupplier);
			}
			return NotFound();
		}

		[HttpPost]
		public IActionResult Edit(Supplier modelEdit, IFormFile FileLogo)
		{
			var existedSupplier = _context.Suppliers.SingleOrDefault(x => x.Id == modelEdit.Id);
			if (existedSupplier != null)
			{
				//Edit
				existedSupplier.Name = modelEdit.Name;
				existedSupplier.Email = modelEdit.Email;
				existedSupplier.Phone = modelEdit.Phone;
				if (FileLogo == null)
				{
					existedSupplier.Logo = modelEdit.Logo;
				}
				else
				{
					existedSupplier.Logo = MyTool.UploadImageToFolder(FileLogo, "Suppliers");
				}
				//Save
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return NotFound();
			}
		}
	}
}
