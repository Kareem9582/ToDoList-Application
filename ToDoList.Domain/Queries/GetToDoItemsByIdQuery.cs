using MediatR;
using ToDoList.Persistence.Entities;

namespace ToDoList.Domain.Queries
{
    public record GetToDoItemsByIdQuery(Guid itemId, string userName) : IRequest<ToDoListItem?>;
}
