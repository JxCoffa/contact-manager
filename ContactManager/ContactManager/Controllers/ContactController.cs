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

	}
}
