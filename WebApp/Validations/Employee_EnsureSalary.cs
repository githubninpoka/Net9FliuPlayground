using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.Validations;

public class Employee_EnsureSalary : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var employee = validationContext.ObjectInstance as Employee;
        if (employee is not null &&
            !string.IsNullOrEmpty(employee.Position) &&
            employee.Position.Equals("Manager", StringComparison.OrdinalIgnoreCase))
        {
            if (employee.Salary < 100_000)
            {
                return new ValidationResult("Managers salary is above 100_000");
            }
        }
        return ValidationResult.Success;
    }
}
