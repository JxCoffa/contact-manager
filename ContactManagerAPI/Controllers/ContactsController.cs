using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManagerAPI.Data;
using ContactManagerAPI.Models;
using ContactManagerAPI.Models.Dtos;

namespace ContactManagerAPI.Controllers
{
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

		// GET: api/contacts/1/jane-doe
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
			var categoryExists = await _context.Categories.AnyAsync(c => c.Id == createDto.CategoryId);
			if (!categoryExists)
			{
				return BadRequest(new
				{
					Error = "CategoryId is not valid",
					ValidCategories = await _context.Categories.Select(c => new { c.Id, c.Name }).ToListAsync()
				});
			}

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

		// PUT: api/contacts/1
		[HttpPut("{id}")]
		public async Task<IActionResult> PutContact(int id, UpdateContactDto updateDto)
		{
			if (id != updateDto.Id)
			{
				return BadRequest("ID mismatching: route and body");
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

			await _context.SaveChangesAsync();
			return NoContent();
		}

		// DELETE: api/contacts/1
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
