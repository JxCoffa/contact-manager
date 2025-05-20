using ContactManager.Models.ViewModels;
using ContactManagerAPI.Models;

namespace ContactManager.Services
{
	public interface IContactService
	{
		Task<IEnumerable<ContactViewModel>> GetAllContactsAsync();
		Task<ContactViewModel> GetContactByIdAsync(int id);
		Task<ContactViewModel> CreateContactAsync(ContactViewModel contact);
		Task UpdateContactAsync(ContactViewModel contact);
		Task DeleteContactAsync(int id);
		Task<IEnumerable<Category>> GetCategoriesAsync();
	}
}
