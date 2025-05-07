using Microsoft.AspNetCore.Mvc;
using WebAppMvc.Models;

namespace WebAppMvc.Controllers;

public class DepartmentsController
{
    public string Index()
    {
        return "These are the departments.";
    }

    public string Details(int? id)
    {
        return $"Department info: {id}";
    }

    [HttpPost]
    [Consumes("application/xml")]
    public object Create([FromBody]Department department)
    {
        return department;
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
