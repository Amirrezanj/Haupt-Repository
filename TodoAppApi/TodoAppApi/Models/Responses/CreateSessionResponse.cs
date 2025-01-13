using TodoAppApi.Data.Entities;

namespace TodoAppApi.Models.Responses
{
    public record CreateSessionResponse(string Token , DateTime Expiry)
    {
        public static CreateSessionResponse FromEntity(UserEntity entity)
        {
            return new CreateSessionResponse(
                entity.SessionToken!,
                entity.TokenExpiry!.Value
                );
        }
    }
}
