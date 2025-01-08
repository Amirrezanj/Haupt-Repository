using TodoAppApi.Data.Entities;

namespace TodoAppApi.Models.Responses
{	
	public record CreateUserResponse(Guid Id, string FirstName, string? SecondName,
		string LastName, string Email)
	{
		public static CreateUserResponse FromEntity(UserEntity request)
		{
			var response = new CreateUserResponse
			(
				request.Id,
				request.FirstName,
				request.SecondName,
				request.LastName,
				request.Email
			);

			return response;
		}
	}
}
