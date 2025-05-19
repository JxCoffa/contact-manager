using System.ComponentModel.DataAnnotations;

namespace ContactManagerAPI.Models.ViewModels
{
	public class Contact
	{
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public string PhoneNumber { get; set; }
		[Required]
		[Range(1, 2)]
		public int CategoryId { get; set; }
	}
}
