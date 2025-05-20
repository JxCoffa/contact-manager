using ContactManager.Services;
using Microsoft.AspNetCore.Mvc;
namespace ContactManager.Controllers
{
	public class ContactController(ContactService contactService) : Controller
	{
		private readonly ContactService _contactService = contactService;

		public async Task<IActionResult> Contacts()
		{
			var contacts = await _contactService.GetContacts();  // This is now List<ContactDto>
			return View(contacts); // Pass the list to your view
		}

	}
}
