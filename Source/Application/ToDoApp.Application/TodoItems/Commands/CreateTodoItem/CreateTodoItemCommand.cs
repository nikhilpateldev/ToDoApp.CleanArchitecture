using MediatR;
using Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Enums;

namespace ToDoApp.Application.TodoItems.Commands.CreateTodoItem
{
    public sealed record CreateTodoItemCommand(
        Guid TodoListId,
        string Title,
        string? Description,
        Priority Priority,
        DateTime? DueDateUtc
    ) : IRequest<Result<Guid>>;
}
