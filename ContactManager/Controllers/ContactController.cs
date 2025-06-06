﻿using ContactManager.Models.ViewModels;  
using ContactManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContactManager.Controllers
{
	public class ContactController : Controller
	{
		private readonly ContactService _contactService;

		public ContactController(ContactService contactService)
		{
			_contactService = contactService;
		}

		public async Task<IActionResult> Index()
		{
			var contacts = await _contactService.GetAllContactsAsync();
			return View(contacts);
		}

		// GET: Contacts/Details/1/jane-doe
		[Route("Contacts/Details/{id}/{slug?}")]
		public async Task<IActionResult> Details(int id, string slug = null)
		{
			var contact = await _contactService.GetContactByIdAsync(id);

			if (contact == null)
			{
				return NotFound();
			}

			return View(contact);
		}

		#region Create
		// GET: Contacts/Create
		public async Task<IActionResult> Create()
		{
			var categories = await _contactService.GetCategoriesAsync();
			var model = new ContactViewModel
			{
				CategoryOptions = new SelectList(categories, "Id", "Name")
			};

			return View(model);
		}

		// POST: Contacts/Create
		[HttpPost]
		public async Task<IActionResult> Create(ContactViewModel contact)
		{
			
				if (ModelState.IsValid)
				{
					var createdContact = await _contactService.CreateContactAsync(contact);

					if (createdContact == null)
					{
						ModelState.AddModelError("", "Failed to create a contact");
					}
					else
					{
						return RedirectToAction(nameof(Details),
							new { id = createdContact.Id, slug = createdContact.Slug });
				}
				}
			var categories = await _contactService.GetCategoriesAsync();
			contact.CategoryOptions = new SelectList(categories, "Id", "Name");
			return View(contact);
		}
		#endregion
		#region Edit
		// GET: Contacts/Edit/1/jane-doe
		[Route("Contacts/Edit/{id}/{slug?}")]

		public async Task<IActionResult> Edit(int id)
		{
			var contact = await _contactService.GetContactByIdAsync(id);
			if (contact == null)
			{
				return NotFound();
			}

			var categories = await _contactService.GetCategoriesAsync();
			contact.CategoryOptions = new SelectList(categories, "Id", "Name", contact.CategoryId);

			return View(contact);
		}

		// POST: Contacts/Edit/5
		[HttpPost]
		[Route("Contacts/Edit/{id}/{slug?}")]
		public async Task<IActionResult> Edit(int id, ContactViewModel contact)
		{
			if (id != contact.Id)
			{
				return NotFound();
			}
			 
			if (ModelState.IsValid)
			{
				try
				{
					await _contactService.UpdateContactAsync(contact);
					return RedirectToAction(nameof(Details),
						new { id = contact.Id, slug = contact.Slug });
				}
				catch
				{
					ModelState.AddModelError("", "Unable to save changes.");
				}
			}

			var categories = await _contactService.GetCategoriesAsync();
			contact.CategoryOptions = new SelectList(categories, "Id", "Name", contact.CategoryId);
			return View(contact);
		}
		#endregion
		#region Delete
		// GET: Contacts/Delete/5/jane-doe
		[Route("Contacts/Delete/{id}/{slug?}")]
		public async Task<IActionResult> Delete(int id, string slug = null)
		{
			var contact = await _contactService.GetContactByIdAsync(id);
			if (contact == null)
			{
				return NotFound();
			}

			return View(contact);
		}

		// POST: Contacts/Delete/5
		[HttpPost, ActionName("Delete")]
		[Route("Contacts/Delete/{id}/{slug?}")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _contactService.DeleteContactAsync(id);
			return RedirectToAction(nameof(Index));
		}
		#endregion
	}
}
