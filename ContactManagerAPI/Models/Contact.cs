using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ContactManagerAPI.Models
{
	public class Contact
	{
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string Phone { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Range(1, 3)]
		public int CategoryId { get; set; }

		public Category Category { get; set; }

		public DateTime DateAdded { get; set; }

		// Full name with - (example: jane-doe)
		public string Slug => $"{FirstName}-{LastName}".ToLowerInvariant().Replace(" ", "-");
	}

}
