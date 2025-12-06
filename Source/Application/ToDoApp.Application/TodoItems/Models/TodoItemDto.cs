using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Enums;

namespace ToDoApp.Application.TodoItems.Models
{
    public sealed record TodoItemDto(
     Guid Id,
     string Title,
     string? Description,
     Priority Priority,
     DateTime? DueDateUtc,
     bool IsCompleted,
     DateTime CreatedOnUtc,
     DateTime? CompletedOnUtc
 );
}
