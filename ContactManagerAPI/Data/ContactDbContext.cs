using ContactManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerAPI.Data
{
	public class ContactDbContext : DbContext
	{
		public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }

		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Seed categories (static data)
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Family" },
				new Category { Id = 2, Name = "Friend" },
				new Category { Id = 3, Name = "Work" }
			);

			// Seed contacts with static dates
			modelBuilder.Entity<Contact>().HasData(
				new Contact
				{
					Id = 1,
					FirstName = "Delores",
					LastName = "Del Rio",
					Phone = "555-987-6543",
					Email = "delores@hotmail.com",
					CategoryId = 2,
					DateAdded = new DateTime(2022, 9, 27, 13, 20, 0) // Static date
				},
				new Contact
				{
					Id = 2,
					FirstName = "Efren",
					LastName = "Herrera",
					Phone = "555-456-7890",
					Email = "efren@aol.com",
					CategoryId = 3,
					DateAdded = new DateTime(2023, 1, 15, 10, 30, 0) // Static date
				},
				new Contact
				{
					Id = 3,
					FirstName = "Mary Ellen",
					LastName = "Walton",
					Phone = "555-123-4567",
					Email = "MaryEllen@yahoo.com",
					CategoryId = 1,
					DateAdded = new DateTime(2023, 2, 20, 9, 15, 0) // Static date
				}
			);
		}
	}
}
