using System.ComponentModel.DataAnnotations;

namespace task_for_66bit.Data.Models;

public class Intern
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public string Gender { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone(ErrorMessage = "Некорректный номер телефона")]
    [RegularExpression(@"^\+7\d{10}$", ErrorMessage = "Phone must start with +7 followed by 10 digits.")]
    public string? PhoneNumber { get; set; } = string.Empty;

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Direction is required")]
    public int? DirectionId { get; set; }
    public Direction Direction { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Project is required")]
    public int? ProjectId { get; set; }
    public Project Project { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}