using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManagerAPI.Data;
using ContactManagerAPI.Models;
using ContactManagerAPI.Models.Dtos;

namespace ContactManagerAPI.Controllers
{
	// ContactsController.cs
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly ContactDbContext _context;

		public ContactsController(ContactDbContext context)
		{
			_context = context;
		}

		// GET: api/contacts
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ContactDto>>> GetContacts()
		{
			return await _context.Contacts
				.Include(c => c.Category)
				.Select(c => new ContactDto
				{
					Id = c.Id,
					FirstName = c.FirstName,
					LastName = c.LastName,
					Phone = c.Phone,
					Email = c.Email,
					CategoryId = c.CategoryId,
					CategoryName = c.Category.Name,
					Slug = c.Slug,
					DateAdded = c.DateAdded
				})
				.ToListAsync();
		}

		// GET: api/contacts/5/delores-del-rio
		[HttpGet("{id}/{slug?}")]
		public async Task<ActionResult<ContactDto>> GetContact(int id, string slug = null)
		{
			var contact = await _context.Contacts
				.Include(c => c.Category)
				.FirstOrDefaultAsync(c => c.Id == id);

			if (contact == null)
			{
				return NotFound();
			}

			return new ContactDto
			{
				Id = contact.Id,
				FirstName = contact.FirstName,
				LastName = contact.LastName,
				Phone = contact.Phone,
				Email = contact.Email,
				CategoryId = contact.CategoryId,
				CategoryName = contact.Category.Name,
				Slug = contact.Slug,
				DateAdded = contact.DateAdded
			};
		}

		// POST: api/contacts
		[HttpPost]
		public async Task<ActionResult<ContactDto>> PostContact(CreateContactDto createDto)
		{
			var contact = new Contact
			{
				FirstName = createDto.FirstName,
				LastName = createDto.LastName,
				Phone = createDto.Phone,
				Email = createDto.Email,
				CategoryId = createDto.CategoryId,
				DateAdded = DateTime.Now
			};

			_context.Contacts.Add(contact);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetContact),
				new { id = contact.Id, slug = contact.Slug },
				new ContactDto
				{
					Id = contact.Id,
					FirstName = contact.FirstName,
					LastName = contact.LastName,
					Phone = contact.Phone,
					Email = contact.Email,
					CategoryId = contact.CategoryId,
					Slug = contact.Slug,
					DateAdded = contact.DateAdded
				});
		}

		// PUT: api/contacts/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutContact(int id, UpdateContactDto updateDto)
		{
			if (id != updateDto.Id)
			{
				return BadRequest();
			}

			var contact = await _context.Contacts.FindAsync(id);
			if (contact == null)
			{
				return NotFound();
			}

			contact.FirstName = updateDto.FirstName;
			contact.LastName = updateDto.LastName;
			contact.Phone = updateDto.Phone;
			contact.Email = updateDto.Email;
			contact.CategoryId = updateDto.CategoryId;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ContactExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// DELETE: api/contacts/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteContact(int id)
		{
			var contact = await _context.Contacts.FindAsync(id);
			if (contact == null)
			{
				return NotFound();
			}

			_context.Contacts.Remove(contact);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool ContactExists(int id)
		{
			return _context.Contacts.Any(e => e.Id == id);
		}
	}
}
