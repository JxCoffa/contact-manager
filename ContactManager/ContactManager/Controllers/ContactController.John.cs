using Microsoft.AspNetCore.Mvc;
using ContactManager.Services;

namespace ContactManager.Controllers
{
	public partial class ContactController 
	{
		public IActionResult Details()
		{
			return View();
		}

		public IActionResult Add()
		{
			return View();
		}

		public IActionResult Edit()
		{
			return View();
		}

		public IActionResult Delete()
		{
			return View();
		}

		public IActionResult Save()
		{
			return View();
		}
	}
}
