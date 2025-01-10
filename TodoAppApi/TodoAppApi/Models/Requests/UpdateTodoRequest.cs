using System.ComponentModel.DataAnnotations;
using TodoAppApi.Attributes;

namespace TodoAppApi.Models.Requests
{
    public record UpdateTodoRequest(
        Guid Id,
        [StringLength(50, MinimumLength = 1)] string Title,
        [StringLength(50, MinimumLength = 1)] string Description,
        [IsFutureDate] DateTime DueDate,
        bool IsDone)
    {
    }
}
