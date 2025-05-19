using System.ComponentModel.DataAnnotations;

namespace ContactManagerAPI.Models.ViewModels
{
	public class Contact
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		[Range(1, 2)]
		public int CategoryId { get; set; }
	}
}
