using ForumSystem.Data;
using ForumSystem.Helpers;
using ForumSystem.Repositories;
using ForumSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ForumSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers(); 
      //      builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ForumContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();

            builder.Services.AddScoped<IForumDataService, ForumDataService>();

            builder.Services.AddScoped<IModelMapper, ModelMapper>();
            builder.Services.AddScoped<IEditPostService, EditPostService>();
            var app = builder.Build();

            //Here we fill DB with information for testing
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<ForumContext>();
                DbInitializer.Initialize(dbContext);
            }
            //  app.MapGet("/", () => "Hello World!");
            app.MapControllers();
            app.UseRouting();

            app.Run();
        }
    }
}