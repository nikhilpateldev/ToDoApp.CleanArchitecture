using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.TodoLists.Models;

namespace ToDoApp.Application.TodoLists.Queries.GetTodoLists
{
    public sealed record GetTodoListsQuery : IRequest<IReadOnlyList<TodoListDto>>;
}
