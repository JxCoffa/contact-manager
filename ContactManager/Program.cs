using ContactManager.Services;

namespace ContactManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			// Configure HttpClient for API calls
			builder.Services.AddHttpClient<IContactService, ContactService>(client =>
			{
				client.BaseAddress = new Uri("https://localhost:7262");
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Contact}/{action=Index}/{id?}/{slug?}");

			app.Run();
		}
    }
}
