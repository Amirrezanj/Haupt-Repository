using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace TodoAppApi.Models.Requests
{
    public record UpdateUserRequest(
        Guid Id,
        string FirstName,
        string? SecondName,
        string LastName,
        string Email) : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FirstName.Length < 5 || FirstName.Length > 15)
            {
                yield return new ValidationResult($"{nameof(FirstName)} must be between 5 and 15", [nameof(FirstName)]);
            }

            if (SecondName != null && (SecondName.Length < 5 || SecondName.Length > 15))
            {
                yield return new ValidationResult($"{nameof(SecondName)} must be between 5 and 15", [nameof(SecondName)]);
            }

            if (LastName.Length < 5 || LastName.Length > 15)
            {
                yield return new ValidationResult($"{LastName} must be between 5 and 15", [nameof(LastName)]);
            }

            if (!MailAddress.TryCreate(Email, out var _))
            {
                yield return new ValidationResult($"{Email} is invalid", [nameof(Email)]);
            }
        }
    }
}
