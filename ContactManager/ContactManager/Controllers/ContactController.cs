using ContactManager.Models;
using System.Diagnostics;
using ContactManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers
{
	public partial class ContactController : Controller
	{
		private readonly ContactService _contactService;

		public ContactController(ContactService contactService)
		{
			_contactService = contactService;
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
