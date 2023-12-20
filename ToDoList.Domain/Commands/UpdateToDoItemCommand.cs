using MediatR;
// Pascal Case is attentional as these are not normal params they will form properties with the same name. 
namespace ToDoList.Domain.Commands
{
    public record UpdateToDoItemCommand(Guid Id, string ItemTitle, string ItemDescription, bool isCompleted, DateTime completionDate, string UserName) : IRequest<int>;
}
