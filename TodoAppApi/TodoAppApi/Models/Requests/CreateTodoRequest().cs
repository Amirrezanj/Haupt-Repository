using System.ComponentModel.DataAnnotations;
using TodoAppApi.Attributes;
using TodoAppApi.Data.Entities;

namespace TodoAppApi.Models.Requests
{
    public record CreateTodoRequest(
        [StringLength(50,MinimumLength = 1,ErrorMessage ="blbla")] string Title ,
        [StringLength(50, MinimumLength = 1)] string Description,
        [IsFutureDate(ErrorMessage ="ist nicht in future")]DateTime DueDate ,
        bool IsDone)
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
