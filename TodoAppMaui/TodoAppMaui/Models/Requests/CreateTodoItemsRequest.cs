using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMaui.Models.Requests
{
    public record CreateTodoItemsRequest(string Title, string Description, DateTime Duedate ,Kategorie Kategorie);
    
}
