using TodoAppApi.Data.Entities;

namespace TodoAppApi.Models.Responses
{
    public record GetTodoResponse(Guid Id, string Title, string Description,
        DateTime DueDate, bool IsDone)
    {
        public static GetTodoResponse FromEntity(TodoEntity entity)
        {
            var response = new GetTodoResponse
                (
                    entity.Id,
                    entity.Title,
                    entity.Description,
                    entity.DueDate,
                    entity.IsDone
                );
            return response;
        }
    }
}
