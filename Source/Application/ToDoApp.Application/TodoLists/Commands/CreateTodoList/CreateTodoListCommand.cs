using MediatR;
using Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.TodoLists.Commands.CreateTodoList
{
    public sealed record CreateTodoListCommand(
        string Name,
        string? Description
    ) : IRequest<Result<Guid>>;
}
