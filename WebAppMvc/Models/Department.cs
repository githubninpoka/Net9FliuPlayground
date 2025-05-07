using System.ComponentModel.DataAnnotations;

namespace WebAppMvc.Models;

public class Department
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [StringLength(500)]
    public string? Description { get; set; }
}
