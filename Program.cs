using Microsoft.EntityFrameworkCore;

namespace ForumSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            builder.Services.AddDbContext<ForumContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}