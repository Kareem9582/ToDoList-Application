using MediatR;
using ToDoList.Persistence.Entities;

namespace ToDoList.Domain.Queries
{
    public record GetToDoItemsListQuery(string userName) : IRequest<IEnumerable<ToDoListItem>>;
}
