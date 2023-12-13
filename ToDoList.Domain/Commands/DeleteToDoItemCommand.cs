using MediatR;

namespace ToDoList.Domain.Commands
{
    public record DeleteToDoItemCommand(Guid Id, string UserName) : IRequest<int>;
}
