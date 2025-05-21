using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContactManagerAPI.Models
{
	/// <summary>
	/// To store the Category names innit
	/// </summary>
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}


}
