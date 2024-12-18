using System.Text.Json;

using AspNet_MVC.Models;
using AspNet_MVC.Services;
using AspNet_MVC.Tables;

using Microsoft.EntityFrameworkCore;

namespace AspNet_MVC;

public class Program
{
    /*
    app.MapGet("",()=>{})
        =>
        Controller("route", service()=>{model.Action()});
            M V C seperation ?
    */


    public static void Main(string[] args)
    {
        /*var auths = JsonSerializer.Deserialize<List<Author>>(File.ReadAllText("Resources/Authors.json"));
        var books = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText("Resources/Books.json"));

        //Added new FK to Books - need to populate from existing auths PK
        //TODO isn't updating!

        *//*books.Select(b =>
        {
            b.authorId = auths.Find(a => a.Name.ToLower() == b.Author.ToLower()).Id;
            return b;
        });*//*
        for(int i = 0; i < books.Count; i++)
        {
            var b = books[i];
            Author a=null;
            for(int j = 0; j < auths.Count; j++)
            {
                var A = auths[j];
                a = b.Author.ToLower() == A.Name.ToLower() ? A : a;
            }

            if(a != null)
            {
                b.authorId = a.Id;
            }
        }*/



        // TESTING ABOVE


        var builder = WebApplication.CreateBuilder(args);        
        builder.Services.AddDbContext<AspMvcDbContext>(o => o.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection") 
        ));

        builder.Services.AddControllers(); //Adding controllers from control folder (controller base class)

        // builder.Services.AddScoped<IAuthorService, AuthorService>();
       // builder.Services.AddScoped<AuthorService, AuthorService>();
        builder.Services.AddScoped<AuthorModel, AuthorModel>();


        var app = builder.Build();

        app.UseRouting(); // allows app to respond to different endpoints

            // Maps given endpoints inside the Controllers folder
        app.UseEndpoints(endpoints => { _ = endpoints.MapControllers(); });

        app.Run(); //Start the app
    }
}
