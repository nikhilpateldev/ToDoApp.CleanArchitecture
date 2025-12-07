using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.Models;
using ToDoApp.Application.TodoLists.Commands.CreateTodoList;
using ToDoApp.Application.TodoLists.Models;
using ToDoApp.Application.TodoLists.Queries.GetTodoLists;

namespace ToDoApp.Api.Controllers
{
    [ApiController]
    [Route("api/todolists")]
    public sealed class TodoListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ApiResponse<IReadOnlyList<TodoListDto>>> Get()
        {
            var lists = await _mediator.Send(new GetTodoListsQuery());

            return new ApiResponse<IReadOnlyList<TodoListDto>>(
                true,
                "Todo lists fetched successfully",
                lists
            );
        }

        [HttpPost]
        public async Task<ApiResponse<Guid>> Create(
            [FromBody] CreateTodoListCommand command)
        {
            var result = await _mediator.Send(command);

            return new ApiResponse<Guid>(
                result.Success,
                result.Success ? "Todo list created successfully" : result.Error!,
                result.Success ? result.Value : Guid.Empty
            );
        }
    }
}
