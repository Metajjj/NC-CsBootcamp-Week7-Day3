using AspNet_MVC.Models;
using AspNet_MVC.Services;
using AspNet_MVC.Controllers;

namespace AspNet_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(); //Adding controllers from control folder (controller base class)

            // builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<AuthorServices, AuthorServices>();
            builder.Services.AddScoped<AuthorModel, AuthorModel>();


            var app = builder.Build();

            app.UseRouting(); // allows app to respond to different endpoints

                // Maps given endpoints inside the Controllers folder
            app.UseEndpoints(endpoints => { _ = endpoints.MapControllers(); });

            app.Run(); //Start the app
        }
    }
}
