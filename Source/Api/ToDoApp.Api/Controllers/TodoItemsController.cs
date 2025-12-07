using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.Models;
using ToDoApp.Application.TodoItems.Commands.CompleteTodoItem;
using ToDoApp.Application.TodoItems.Commands.CreateTodoItem;

namespace ToDoApp.Api.Controllers
{

    [ApiController]
    [Route("api/todoitems")]
    public sealed class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ApiResponse<Guid>> Create(
            [FromBody] CreateTodoItemCommand command)
        {
            var result = await _mediator.Send(command);

            return new ApiResponse<Guid>(
                result.Success,
                result.Success ? "Todo item created successfully" : result.Error!,
                result.Success ? result.Value : Guid.Empty
            );
        }

        [HttpPost("{id:guid}/complete")]
        public async Task<ApiResponse<object>> Complete(Guid id)
        {
            var result = await _mediator.Send(new CompleteTodoItemCommand(id));

            return new ApiResponse<object>(
                result.Success,
                result.Success ? "Todo item completed" : result.Error!,
                null
            );
        }
    }
}
