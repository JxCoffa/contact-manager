using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models.ViewModels
{
	// ContactViewModel.cs
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

		[Range(1, int.MaxValue)]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public SelectList CategoryOptions { get; set; }

		public string Slug { get; set; }

		[Display(Name = "Date Added")]
		public DateTime DateAdded { get; set; }

		[Display(Name = "Category")]
		public string CategoryName { get; set; }

		[Display(Name = "Name")]
		public string FullName => $"{FirstName} {LastName}";
	}
}
