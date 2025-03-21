using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace task_for_66bit.Data.Models;

public class Intern
{
    public int Id { get; set; }

    [Required(ErrorMessage = "'Имя' обязательно к заполнению.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "'Фамилия' обязательно к заполнению.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "'Пол' обязательно к заполнению.")]
    public string Gender { get; set; } = string.Empty;

    [Required(ErrorMessage = "'Email' обязательно к заполнению.")]
    [EmailAddress(ErrorMessage = "Некорректный формат email.")]
    public string Email { get; set; } = string.Empty;

    [CustomValidation(typeof(Intern), nameof(ValidatePhoneNumber))]
    public string? PhoneNumber { get; set; } = string.Empty;

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "'Направление' обязательно к заполнению")]
    public int? DirectionId { get; set; }
    public Direction Direction { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "'Проект' обязательно к заполнению")]
    public int? ProjectId { get; set; }
    public Project Project { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public static ValidationResult? ValidatePhoneNumber(string? phoneNumber, ValidationContext context)
    {
        if (string.IsNullOrEmpty(phoneNumber))
        {
            var instance = context.ObjectInstance;
            var propertyInfo = instance.GetType().GetProperty(context.MemberName!);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(instance, null);
            }

            return ValidationResult.Success;
        }

        var regex = new Regex(@"^\+7\d{10}$");
        if (!regex.IsMatch(phoneNumber))
        {
            return new ValidationResult("Телефон должен начинаться с +7 и состоять из 11 цифр.");
        }

        return ValidationResult.Success;
    }
}