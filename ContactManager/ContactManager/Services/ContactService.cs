namespace ContactManager.Services
{
	public class ContactService
	{
		// The dedicated phone line the chef uses to contact the supplier
		private readonly HttpClient _httpClient;

		// The kitchen manager who provides the phone line (HttpClient)
		public ContactService(IHttpClientFactory httpClientFactory)
		{
			// The chef gets the specific supplier's line from the manager
			_httpClient = httpClientFactory.CreateClient("ContactAPI");
		}
	}
}
