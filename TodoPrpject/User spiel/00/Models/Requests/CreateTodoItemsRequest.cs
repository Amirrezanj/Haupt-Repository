﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Models.Requests
{
    public record CreateTodoItemsRequest(string Title,string Description,DateTime Duedate);
}
