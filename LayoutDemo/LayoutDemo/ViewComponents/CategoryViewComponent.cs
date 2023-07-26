using LayoutDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace LayoutDemo.ViewComponents
{
	public class CategoryViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			//thực hiện đọc thông tin từ database
			var danhMuc = new List<CategoryModel>
				{
					new CategoryModel{Id=1, Name = "Laptopew"},
					new CategoryModel{Id=2, Name = "Tablet"},
					new CategoryModel{Id=3, Name = "Smartphone"},
				};

			return View(danhMuc);
		}
	}
}
