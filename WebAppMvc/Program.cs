namespace WebAppMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllers();
            //builder.Services.AddControllersWithViews();
            // for razor pages?

            var app = builder.Build();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                // method that tells .net to find all controllers
                endpoints.MapControllers();
            });
            //app.MapControllers();
            // works just as well only less explicit

            app.Run();
        }
    }
}
