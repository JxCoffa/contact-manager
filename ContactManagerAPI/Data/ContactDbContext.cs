using ContactManagerAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerAPI.Data
{
	public class ContactDbContext(DbContextOptions<ContactDbContext> options) : DbContext(options)
	{
		public DbSet<Contact> Contacts { get; set; }
	}
}
