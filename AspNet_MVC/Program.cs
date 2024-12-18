namespace AspNet_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(); //Adding controllers from control folder (controller base class)

            var app = builder.Build();

            app.UseRouting(); // ??

                // ??
            app.UseEndpoints(endpoints => { _ = endpoints.MapControllers(); });

            app.Run(); //Start the app
        }
    }
}
