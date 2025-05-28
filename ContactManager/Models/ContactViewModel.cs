using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManager.Models.ViewModels
{
	public class ContactViewModel
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required]
		[Phone]
		public string Phone { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		[ValidateNever]
		public SelectList CategoryOptions { get; set; }

		[ValidateNever]
		public string Slug { get; set; }

		[ValidateNever]
		public string CategoryName { get; set; }

		[Display(Name = "Date Added")]
		[ValidateNever]
		public DateTime DateAdded { get; set; }

		[ValidateNever]
		[Display(Name = "Name")]
		public string FullName => $"{FirstName} {LastName}";
	}
}
