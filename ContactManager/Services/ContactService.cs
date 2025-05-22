using ContactManager.Models.ViewModels;
using ContactManagerAPI.Models;
using ContactManagerAPI.Models.Dtos;

namespace ContactManager.Services
{
	public class ContactService
	{
		private readonly HttpClient _httpClient;
		// gives it the rights to read the appsettings.json
		// "ApiBaseUrl": "https://localhost:7262",
		private readonly IConfiguration _configuration;

		// Initialize ContactService with HttpClient and configuration,
		// setting the HttpClients base uri from the apps settings.
		// and when you call it you will get it with it
		public ContactService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
			_httpClient.BaseAddress = new Uri(_configuration["ApiBaseUrl"]);
		}

		public async Task<IEnumerable<ContactViewModel>> GetAllContactsAsync()
		{
			var response = await _httpClient.GetAsync("api/contacts");
			response.EnsureSuccessStatusCode();

			var contacts = await response.Content.ReadFromJsonAsync<IEnumerable<ContactViewModel>>();
			return contacts ?? Enumerable.Empty<ContactViewModel>();
		}

		public async Task<ContactViewModel> GetContactByIdAsync(int id)
		{
			var response = await _httpClient.GetAsync($"api/contacts/{id}");
			response.EnsureSuccessStatusCode();

			return await response.Content.ReadFromJsonAsync<ContactViewModel>();
		}

		public async Task<ContactViewModel> CreateContactAsync(ContactViewModel contact)
		{
			var response = await _httpClient.PostAsJsonAsync("api/contacts", contact);
			response.EnsureSuccessStatusCode();

			return await response.Content.ReadFromJsonAsync<ContactViewModel>();
		}

		public async Task UpdateContactAsync(ContactViewModel contact)
		{
			var response = await _httpClient.PutAsJsonAsync($"api/contacts/{contact.Id}", contact);
			response.EnsureSuccessStatusCode();
		}

		public async Task DeleteContactAsync(int id)
		{
			var response = await _httpClient.DeleteAsync($"api/contacts/{id}");
			response.EnsureSuccessStatusCode();
		}

		public async Task<IEnumerable<Category>> GetCategoriesAsync()
		{
			var response = await _httpClient.GetAsync("api/categories");
			response.EnsureSuccessStatusCode();

			return await response.Content.ReadFromJsonAsync<IEnumerable<Category>>();
		}
	}
}
