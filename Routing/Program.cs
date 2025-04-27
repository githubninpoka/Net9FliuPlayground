var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// app.UseEndpoints is no longer necessary, but when creating a mapget or mappost
// .net will still under the hood place them inside useendpoints. it's just 'hidden'.
// so why hide what's going on? this is pretty clear
// whatchadoing? you are creating endpoints that are used by the useendpoints middleware!

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/employees", async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Get Employees");
    });
    endpoints.MapPost("/employees", async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Post Employees");
    });
});

app.Run();
