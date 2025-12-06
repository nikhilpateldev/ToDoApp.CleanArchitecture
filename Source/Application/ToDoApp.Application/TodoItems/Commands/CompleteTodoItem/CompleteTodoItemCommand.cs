using MediatR;
using Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.TodoItems.Commands.CompleteTodoItem
{
    public sealed record CompleteTodoItemCommand(
        Guid TodoItemId
    ) : IRequest<Result>;
}
