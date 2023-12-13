using MediatR;

namespace ToDoList.Domain.Commands
{
    public record MarkAsCompleteCommand(Guid Id, string UserName) : IRequest<int>;
}
