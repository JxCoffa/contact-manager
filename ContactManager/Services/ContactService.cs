using ContactManager.Models.Dtos;
using ContactManagerAPI.Models.ViewModels;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace ContactManager.Services
{
	public class ContactService
	{
		private readonly HttpClient _httpClient;
		private const string baseUrl = "https://localhost:7262/api";

		// Getting a chef from the kitchen list that will be called when you make a request
		public	ContactService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("ContactApi");
		}

		public async Task<List<ContactDto>> GetContacts()
		{
			string url = $"{baseUrl}/Contacts/";
			var json = await _httpClient.GetStringAsync(url);

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};

			return JsonSerializer.Deserialize<List<ContactDto>>(json, options);
		}
	}
}
