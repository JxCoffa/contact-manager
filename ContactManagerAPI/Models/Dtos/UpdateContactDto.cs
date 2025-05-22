using System.ComponentModel.DataAnnotations;

namespace ContactManagerAPI.Models.Dtos
{
	public class UpdateContactDto 
	{
			[Required]
			[Range(1, int.MaxValue)]
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

			[Range(1, 3, ErrorMessage = "CategoryId must be 1 (Family), 2 (Friend), or 3 (Work)")]
			public int CategoryId { get; set; }
	}
}
