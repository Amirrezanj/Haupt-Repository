using TodoAppApi.Data.Entities;

namespace TodoAppApi.Models.Responses
{
    public record GetUserResponse(Guid Id , string FirstName , string LastName ,string Email)
    {
        public static GetUserResponse FromEntity(UserEntity entity)
        {
            var response = new GetUserResponse
            (
                entity.Id,
                entity.FirstName,
                entity.LastName,
                entity.Email
            );
            return response;
        }

    }
}