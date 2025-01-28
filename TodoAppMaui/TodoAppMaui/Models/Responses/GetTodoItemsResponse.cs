using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMaui.Models.Responses
{
    public record GetTodoItemsResponse(Guid Id, string Title, string Description, DateTime Duedate, bool IsComplete);
}
