using ContactManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerAPI.Data
{
	public class ContactDbContext : DbContext
	{
		/// <summary>
		/// Initializses the dbcontext with options,
		/// which specify how to connect to and configure the database.
		/// </summary>
		public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }

		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Category> Categories { get; set; }

		/// <summary>
		/// Sets up some starting data for the database, like categories and example contacts,
		/// this runs when the database is being created or updated.
		/// </summary>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// CategoryId categories 
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Family" },
				new Category { Id = 2, Name = "Friend" },
				new Category { Id = 3, Name = "Work" }
			);

			// Test data for contact
			modelBuilder.Entity<Contact>().HasData(
				new Contact
				{
					Id = 1,
					FirstName = "Jane",
					LastName = "Doe",
					Phone = "555-987-6543",
					Email = "Jdoe@hotmail.com",
					CategoryId = 2,
					DateAdded = new DateTime(2022, 9, 27, 13, 20, 0) // September 27, 2022 at 1:20:00 PM
				},
				new Contact
				{
					Id = 2,
					FirstName = "Yuan",
					LastName = "Zhu",
					Phone = "555-456-7890",
					Email = "ZYuan@gmail.com",
					CategoryId = 3,
					DateAdded = new DateTime(2023, 1, 15, 10, 30, 0) 
				},
				new Contact
				{
					Id = 3,
					FirstName = "Nicole",
					LastName = "Demara",
					Phone = "555-123-4567",
					Email = "NDemara@yahoo.com",
					CategoryId = 1,
					DateAdded = new DateTime(2023, 2, 20, 9, 15, 0)
				}
			);
		}
	}
}
