using MediatR;
using ToDoList.Api.Contracts;
using ToDoList.Domain.Queries;
using ToDoList.Persistence.Entities;

namespace ToDoList.Api.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IMediator _mediator;
        public ToDoListService(IMediator mediator)
        {
                _mediator = mediator;
        }
        public async Task<IEnumerable<ToDoListItem>> GetItems(string userName)
        {
            return await _mediator.Send(new GetToDoItemsListQuery(userName));
        }
    }
}
