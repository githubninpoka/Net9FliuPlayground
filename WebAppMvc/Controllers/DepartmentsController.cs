using Microsoft.AspNetCore.Mvc;
using WebAppMvc.Models;

namespace WebAppMvc.Controllers;

//[ApiController]
//[Route("/departments")]
// just for reference, by adding this attribute, the controller starts behaving differently.
// instead of processing a request with model errors, the api will immediately short circuit and throw an error
// for this to work, the endpoint itself must also have a route defined. (!)

public class DepartmentsController : Controller // controller base class provides access to ModelState that would otherwise not be available...
{
    public IActionResult Index()
    {
        return Content("These are the departments.<h2>this can spit out HTML</h2>",contentType: "text/html");
    }

    public string Details(int? id)
    {
        return $"Department info: {id}";
    }

    [HttpPost]
    [Consumes("application/xml")]
    //[Route("create")]
    public IActionResult Create([FromBody]Department department)
    {
        ModelState.AddModelError("TestKey","TestErrorValue");
        foreach(var value in ModelState.Values)
        {
            foreach (var error in value.Errors)
            {
                Console.WriteLine($"One error: {error.ErrorMessage}");
            }
        }
        // we can do something with the modelstate here. but probably somewhere in the filterpipeline there is something better...

        return new JsonResult(department);
    }

    [HttpPost]
    public string Delete(int? id)
    {
        return $"Deleted department: {id}";
    }

    [HttpPost]
    public string Edit(int? id)
    {
        return $"Updated department: {id}";
    }
}
