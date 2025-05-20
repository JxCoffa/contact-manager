namespace ContactManagerAPI.Models.Dtos
{
	public class ContactDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string Slug { get; set; }
		public DateTime DateAdded { get; set; }
	}

}
