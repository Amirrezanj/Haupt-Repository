using System.ComponentModel.DataAnnotations;
using TodoAppApi.Data.Entities;
using TodoAppApi.Data.Entities;

namespace TodoAppApi.Models.Requests
{
	public record CreateUserRequest(
		[StringLength(50,MinimumLength =1)]string FirstName,
        [StringLength(50, MinimumLength = 1)] string? SecondName,
        [StringLength(50, MinimumLength = 1)] string LastName,
		string Email, 
		CreateAddressRequest Address) : IValidatableObject
	{

		public static UserEntity ToEntity(CreateUserRequest request)
		{
			var entity = new UserEntity
			{
				FirstName = request.FirstName,
				SecondName = request.SecondName,
				LastName = request.LastName,
				Email = request.Email,
				Address = CreateAddressRequest.ToEntity(request.Address)
			};

			return entity;
			
		}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
			if (FirstName.Length + LastName.Length > 25)
			{
				yield return new ValidationResult("First and Last Name combined to long", [nameof(FirstName),nameof(LastName)]);
			}
        }
    }
}