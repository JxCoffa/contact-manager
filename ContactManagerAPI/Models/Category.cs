using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContactManagerAPI.Models
{
	// Category.cs
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}


}
