using TodoAppApi.Data.Entities;

namespace TodoAppApi.Models.Responses
{
    public record UpdateUserResponse(Guid Id, string FirstName, string? SecondName,
        string LastName, string Email)
    {
        public static UpdateUserResponse FromEntity(UserEntity entity)
        {
            var response = new UpdateUserResponse(
                entity.Id,
                entity.FirstName,
                entity.SecondName,
                entity.LastName,
                entity.Email
                
            );

            return response;
        }
    }
}
