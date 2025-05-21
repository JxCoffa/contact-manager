using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManagerAPI.Data;
using ContactManagerAPI.Models;

namespace ContactManagerAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ContactDbContext _context;

		public CategoriesController(ContactDbContext context)
		{
			_context = context;
		}

		// GET: api/categories
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
		{
			return await _context.Categories.ToListAsync();
		}
	}
}