
using Microsoft.EntityFrameworkCore;
using onetoneRelationship.Models;

namespace onetoneRelationship
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Read connection string from appsettings.json
            var configuration = builder.Configuration;
            var sqlConnectionString = configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(sqlConnectionString);
            });

            // Write connection string to output (for demonstration purposes)
            Console.WriteLine($"SQL Connection String: {sqlConnectionString}");
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