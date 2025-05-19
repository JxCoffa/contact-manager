
using ContactManagerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			var connectionString =
			builder.Configuration.GetConnectionString("ContactManagerDatabase")
			?? throw new InvalidOperationException("Connection string"
			+ "'DefaultConnection' not found.");

			builder.Services.AddDbContext<ContactDbContext>(options =>
				options.UseSqlServer(connectionString));
			builder.Services.AddControllers();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
