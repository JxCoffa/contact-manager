using System.ComponentModel.DataAnnotations;

namespace ContactManagerAPI.Models.Dtos
{
	public class CreateContactDto
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string Phone { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Range(1, int.MaxValue)]
		public int CategoryId { get; set; }
	}
}
