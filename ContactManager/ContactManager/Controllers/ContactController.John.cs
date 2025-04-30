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
	}
}
