using MediatR;
using Shared.Common.Models;
using Shared.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDoApp.Application.TodoLists.Commands.CreateTodoList
{
    public sealed class CreateTodoListCommandHandler
    : IRequestHandler<CreateTodoListCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTodoListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(
            CreateTodoListCommand request,
            CancellationToken cancellationToken)
        {
            var list = new TodoList(request.Name, request.Description);

            var repo = _unitOfWork.Repository<TodoList>();

            await repo.AddAsync(list, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Ok(list.Id);
        }
    }
}
