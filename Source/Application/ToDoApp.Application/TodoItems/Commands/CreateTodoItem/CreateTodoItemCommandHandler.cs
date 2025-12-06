using MediatR;
using Shared.Common.Exceptions;
using Shared.Common.Models;
using Shared.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDoApp.Application.TodoItems.Commands.CreateTodoItem
{
    public sealed class CreateTodoItemCommandHandler
    : IRequestHandler<CreateTodoItemCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTodoItemCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(
            CreateTodoItemCommand request,
            CancellationToken cancellationToken)
        {
            var listRepo = _unitOfWork.Repository<TodoList>();

            var list = await listRepo.GetByIdAsync(request.TodoListId, cancellationToken);

            if (list is null)
                throw new NotFoundException(nameof(TodoList), request.TodoListId);

            var item = list.AddItem(
                request.Title,
                request.Description,
                request.Priority,
                request.DueDateUtc);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Ok(item.Id);
        }
    }

}
