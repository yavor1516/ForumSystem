using ForumSystem.Data;
using ForumSystem.Helpers;
using ForumSystem.Repositories;
using ForumSystem.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ForumSystem.Services.TokenGenerator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ForumSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews(); 
           
      //      builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ForumContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });
            builder.Services.AddAuthorization();
            // //////////////////////////builder.Configuration.
            //AuthenticationSecretKey with appSettings Bind to specific Object!!
            AuthenticationConfiguration authenticationConfiguration = new AuthenticationConfiguration();
            builder.Configuration.Bind("Authentication", authenticationConfiguration);
            builder.Services.AddSingleton(authenticationConfiguration);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o => o.TokenValidationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationConfiguration.AccessTokenSecret)),
                ValidIssuer = authenticationConfiguration.Issuer,
                ValidAudience = authenticationConfiguration.Audience,
                ValidateIssuerSigningKey =true,
                ValidateIssuer = true,
                ValidateAudience = true,
                
            });


            ////////////////////////////////////////////////////////////////////////////////////////////////////

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
          
            builder.Services.AddScoped<IForumDataService, ForumDataService>();

            builder.Services.AddScoped<IModelMapper, ModelMapper>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<AccessTokenGenerator>();
            builder.Services.AddScoped<ITokenReader, ForumSystem.Helpers.TokenReader>();
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
            builder.Services.AddScoped<ICreateCommentService, CreateCommentService>();
            builder.Services.AddScoped<IEditPostService, EditPostService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IUserDataService, UserDataService>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<IPostVoteService, PostVoteService>();
            builder.Services.AddScoped<IAdminPanelService, AdminPanelService>();
            var app = builder.Build();

            //Here we fill DB with information for testing
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<ForumContext>();
                DbInitializer.Initialize(dbContext);
            }
            app.MapControllerRoute(
                name: "post",
                pattern: "post/{id:int}",
                defaults: new { controller = "Post", action = "Index" });
            app.MapControllerRoute(
                 name: "delete",
                 pattern: "post/delete/{itemId:int}", // Change the pattern to be more specific
                 defaults: new { controller = "Post", action = "Delete" });
            app.MapControllerRoute(
             name: "editComment",
             pattern: "post/edit/{itemId:int}/{content?}", // Updated pattern for editing
             defaults: new { controller = "Post", action = "EditComment" });
			app.MapControllerRoute(
			name: "createComment",
			pattern: "post/createComment/{content?}", // Updated pattern for editing
			defaults: new { controller = "Post", action = "CreateComment" });
			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //  app.MapGet("/", () => "Hello World!");
            app.UseStaticFiles();
            app.MapDefaultControllerRoute();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.Run();
        }
    }
}