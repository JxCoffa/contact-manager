using Microsoft.AspNetCore.Mvc;

namespace ContactManagerAPI.Controllers
{
	public class ContactsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
