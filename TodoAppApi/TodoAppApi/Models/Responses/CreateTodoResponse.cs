﻿using TodoAppApi.Collections;
using TodoAppApi.Data.Entities;

namespace TodoAppApi.Models.Responses
{
    public record CreateTodoResponse(Guid Id, string Title, string Description,
       DateTime DueDate, bool IsDone , Kategorie Kategorie)
    {
        public static CreateTodoResponse FromEntity(TodoEntity entity)
        {
            var response = new CreateTodoResponse
                (
                    entity.Id,
                    entity.Title,
                    entity.Description,
                    entity.DueDate,
                    entity.IsDone,
                    entity.Kategorie
                );
            return response;
        }
    }
}
