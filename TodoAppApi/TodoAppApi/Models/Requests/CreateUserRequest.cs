using Microsoft.OpenApi.Validations;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using TodoAppApi.Data.Entities;
using TodoAppApi.Data.Entities;
using TodoAppApi.Helpers;

namespace TodoAppApi.Models.Requests
{
	public record CreateUserRequest(
		string FirstName,
        string? SecondName,
        string LastName,
		string Email, 
		string Password,
		CreateAddressRequest Address) : IValidatableObject
	{

		public static UserEntity ToEntity(CreateUserRequest request)
		{
			var salt = PasswordHelper.GenerateSalt();
			var hash = PasswordHelper.HashPassword(request.Password,salt);

			var entity = new UserEntity
			{
				FirstName = request.FirstName,
				SecondName = request.SecondName,
				LastName = request.LastName,
				Email = request.Email,
				PasswordSalt = salt,
				PasswordHash = hash,
				Address = CreateAddressRequest.ToEntity(request.Address)
			};

			return entity;
			
		}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
			if (FirstName.Length <5|| FirstName.Length > 15)
			{
				yield return new ValidationResult($"{nameof(FirstName)} must be between 5 und 15", [nameof(FirstName)]);
			}
            if (SecondName!=null &&(SecondName.Length < 5||SecondName.Length>15))
            {
                yield return new ValidationResult($"{nameof(SecondName)} must be between 5 und 15", [nameof(SecondName)]);
            }
            if (LastName.Length < 5 || LastName.Length > 15)
            {
                yield return new ValidationResult($"{LastName} must be between 5 und 15", [nameof(LastName)]);
            }
            if (!MailAddress.TryCreate(Email,out var _))
            {
                yield return new ValidationResult($"{Email} is invalid", [nameof(Email)]);
            }
        }
    }
}