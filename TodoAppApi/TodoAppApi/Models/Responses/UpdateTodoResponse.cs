using TodoAppApi.Data.Entities;

namespace TodoAppApi.Models.Responses
{
    public record UpdateTodoResponse(Guid Id, string Title, string Description,
        DateTime DueDate, bool IsDone)
    {
        public static UpdateTodoResponse FromEntity(TodoEntity entity)
        {
            var response = new UpdateTodoResponse(
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
