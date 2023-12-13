using MediatR;
using ToDoList.Domain.Objects;
using ToDoList.Persistence.Entities;

namespace ToDoList.Domain.Queries
{
    public record SearchListQuery(Filter filter, string userName) : IRequest<IEnumerable<ToDoListItem>>;
}
