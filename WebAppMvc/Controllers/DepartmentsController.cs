using Microsoft.AspNetCore.Mvc;

namespace WebAppMvc.Controllers;

//[Controller]
// one way of specifying that a class is a controller

// set a route for the controller
[Route("/api")]
public class DepartmentsController : Controller
    // another way is the naming convention
    // .net core is able to understand that it's a controller
    // by the suffix Controller
    // another way, I guess is by inheriting from controller
    // we'll see later on if i mess stuff up
{
    //[HttpGet]
    //[Route("/departments")]
    [HttpGet("departments")]
    public string GetDepartments()
    {
        return "departments";
    }

    //[HttpGet]
    //[Route("/departments/{id:int}")]
    [HttpGet("departments/{id:int}")]
    public string GetDepartmentById(int id)
    {
        return $"Department info {id}";
    }

    // annotation to state that an action will not become
    // an action in the controller
    [NonAction]
    public string GetDepartmentByName(string name)
    {
        return "Not an action";
    }
}
