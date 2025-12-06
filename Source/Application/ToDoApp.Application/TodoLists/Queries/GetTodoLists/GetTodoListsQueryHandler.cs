using MediatR;
using Shared.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDoApp.Application.TodoLists.Models;

namespace ToDoApp.Application.TodoLists.Queries.GetTodoLists
{
    public sealed class GetTodoListsQueryHandler
    : IRequestHandler<GetTodoListsQuery, IReadOnlyList<TodoListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTodoListsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<TodoListDto>> Handle(
            GetTodoListsQuery request,
            CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<TodoList>();

            var lists = await repo.GetAllAsync(cancellationToken);

            var result = lists
                .Select(l => new TodoListDto(
                    l.Id,
                    l.Name,
                    l.Description,
                    l.CreatedOnUtc,
                    l.Items.Count
                ))
                .ToList();

            return result;
        }
    }
}
