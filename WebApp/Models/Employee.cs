using System.ComponentModel.DataAnnotations;
using WebApp.Validations;

namespace WebApp.Models;

public class Employee
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string Position { get; set; }

    [Employee_EnsureSalary]
    public double Salary { get; set; }

    public Employee(int id, string name, string position, double salary)
    {
        Id = id;
        Name = name;
        Position = position;
        Salary = salary;
    }
}
