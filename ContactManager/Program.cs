using ContactManager.Services;

namespace ContactManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
			// Hire a chef named ContactApi.
			// When that chef prepares food (makes HTTP requests),
			// always start from the restaurant at https://localhost:7262.
			builder.Services.AddHttpClient( "ContactApi", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7262");
            });

            // Add services to the container.
            

			builder.Services.AddScoped<ContactService>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Contact}/{action=Contacts}/{id?}");

            app.Run();
        }
    }
}
