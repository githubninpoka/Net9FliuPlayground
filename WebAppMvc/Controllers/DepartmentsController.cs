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
    [HttpGet]
    public IActionResult Index()
    {
        var departments = DepartmentsRepository.GetDepartments();

        return View(departments);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var department = DepartmentsRepository.GetDepartmentById(id);
        if (department == null)
        {
            return View("Error",new List<string>() { "Department not found." });
        }

        return View(department);

    }

    [HttpPost]
    public IActionResult Edit(Department department)
    {
        if (!ModelState.IsValid)
        {
            return View("Error", GetErrors());
        }

        DepartmentsRepository.UpdateDepartment(department);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new Department());
    }

    [HttpPost]
    public IActionResult Create(Department department)
    {
        if (!ModelState.IsValid)
        {
            return View("Error", GetErrors());
        }

        DepartmentsRepository.AddDepartment(department);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var department = DepartmentsRepository.GetDepartmentById(id);
        if (department == null)
        {
            ModelState.AddModelError("id", "Department not found.");

            return View("Error", GetErrors());
        }

        DepartmentsRepository.DeleteDepartment(department);

        return RedirectToAction(nameof(Index));
    }

    private List<string> GetErrors()
    {
        List<string> errorMessages = new List<string>();
        foreach (var value in ModelState.Values)
        {
            foreach (var error in value.Errors)
            {
                errorMessages.Add(error.ErrorMessage);
            }
        }

        return errorMessages;
    }
}
