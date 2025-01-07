using TodoAppApi.Data.Entities;

namespace TodoAppApi.Models.Requests
{
    public record CreateTodoRequest(string Title , string Description,
        DateTime DueDate , bool IsDone)
    {
        public static TodoEntity ToEntity(CreateTodoRequest request)
        {
            var entity = new TodoEntity
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                IsDone = request.IsDone
            };
            return entity;
        }
    }
}
