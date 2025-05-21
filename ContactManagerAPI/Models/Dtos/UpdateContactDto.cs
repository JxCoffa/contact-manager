using System.ComponentModel.DataAnnotations;

namespace ContactManagerAPI.Models.Dtos
{
	public class UpdateContactDto 
	{
			[Required]
			[Range(1, int.MaxValue)]
			public int Id { get; set; }  // Must be required integer

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
	}
}
