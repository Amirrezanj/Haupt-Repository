using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppApi.Collections;

namespace TodoAppApi.Data.Entities
{
    public class TodoEntity
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required DateTime DueDate { get; set; }
        public bool IsDone {  get; set; }
        public UserEntity User { get; set; }
        public required Kategorie Kategorie { get; set; }
    }
}
