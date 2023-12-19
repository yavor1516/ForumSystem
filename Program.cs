using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ForumSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ForumContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });
            var app = builder.Build();
            
            //app.MapGet("/", () => "Hello World!");
            app.UseRouting();

            app.Run();
        }
    }
}