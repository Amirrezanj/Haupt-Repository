﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Models.Responces
{
    public record UpdateTodoItemResponse(Guid Id, string Title, string Description, DateTime DueDate, bool IsComplete);    
    
}
