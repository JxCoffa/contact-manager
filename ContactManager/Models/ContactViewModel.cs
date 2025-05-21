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

		// i dont want to map this because you cant enter info innit 
		// which can cause errors so im telling the model binding im skipping this 
		// and not putting it in the Db
		[ValidateNever]
		public SelectList CategoryOptions { get; set; }

		[ValidateNever]
		public string Slug { get; set; }

		[ValidateNever]
		public string CategoryName { get; set; }

		[Display(Name = "Date Added")]
		public DateTime DateAdded { get; set; }

		[Display(Name = "Name")]
		public string FullName => $"{FirstName} {LastName}";
	}
}
