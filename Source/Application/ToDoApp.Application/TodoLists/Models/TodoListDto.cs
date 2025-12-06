using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.TodoLists.Models
{
    public sealed record TodoListDto(
     Guid Id,
     string Name,
     string? Description,
     DateTime CreatedOnUtc,
     int ItemsCount
 );
}
