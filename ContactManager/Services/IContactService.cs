using ContactManager.Models.ViewModels;
using ContactManagerAPI.Models;

namespace ContactManager.Services
{
	/// <summary>
	/// Provides methods to work with contacts and categories,
	/// like getting, adding, updating, and deleting contact information.
	/// 
	/// interface is like a promise that a class makes to have these actions,
	/// but it doesn't say how to do them.
	/// </summary>
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
