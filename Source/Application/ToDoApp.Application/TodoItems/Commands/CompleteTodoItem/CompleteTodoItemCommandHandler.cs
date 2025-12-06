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

namespace ToDoApp.Application.TodoItems.Commands.CompleteTodoItem
{
    public sealed class CompleteTodoItemCommandHandler
    : IRequestHandler<CompleteTodoItemCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompleteTodoItemCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(
            CompleteTodoItemCommand request,
            CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<TodoItem>();

            var item = await repo.GetByIdAsync(request.TodoItemId, cancellationToken);

            if (item is null)
                throw new NotFoundException(nameof(TodoItem), request.TodoItemId);

            item.Complete();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
