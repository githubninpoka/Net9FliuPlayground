using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApp.Models;
using WebApp.ResultTypes;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddProblemDetails();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", HtmlResult () =>
                {
                    string html = "<h2>Welcome to our API</h2> Our API is used to learn ASP.NET CORE.";

                    return new HtmlResult(html);
                });

                endpoints.MapGet("/employees", () =>
                {
                    var employees = EmployeesRepository.GetEmployees();

                    return TypedResults.Ok(employees);
                });

                endpoints.MapPost("/employees", (Employee employee) =>
                {
                    if (employee is null || employee.Id < 0)
                    {
                        return Results.ValidationProblem(new Dictionary<string, string[]>
                            {
                                {"id", new[] { "Employee is not provided or is not valid." } }
                            });
                    }

                    EmployeesRepository.AddEmployee(employee);
                    return TypedResults.Created($"/employees/{employee.Id}", employee);

                }).WithParameterValidation();



                endpoints.MapPut("/employees", async (HttpContext context) =>
                {
                    using var reader = new StreamReader(context.Request.Body);
                    var body = await reader.ReadToEndAsync();
                    var employee = JsonSerializer.Deserialize<Employee>(body);

                    var result = EmployeesRepository.UpdateEmployee(employee);
                    if (result)
                    {
                        context.Response.StatusCode = 204;
                        await context.Response.WriteAsync("Employee updated successfully.");
                        return;
                    }
                    else
                    {
                        await context.Response.WriteAsync("Employee not found.");
                    }
                });

                endpoints.MapDelete("/employees/{id}", async (HttpContext context) =>
                {

                    var id = context.Request.RouteValues["id"];
                    var employeeId = int.Parse(id.ToString());

                    if (context.Request.Headers["Authorization"] == "frank")
                    {
                        var result = EmployeesRepository.DeleteEmployee(employeeId);

                        if (result)
                        {
                            await context.Response.WriteAsync("Employee is deleted successfully.");
                        }
                        else
                        {
                            context.Response.StatusCode = 404;
                            await context.Response.WriteAsync("Employee not found.");
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("You are not authorized to delete.");
                    }

                });

            });
            app.Run();
        }
    }

}
