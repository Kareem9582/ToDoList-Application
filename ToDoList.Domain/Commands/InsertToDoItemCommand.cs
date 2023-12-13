using MediatR;
// Pascal Case is attentional as these are not normal params they will form properties with the same name. 
namespace ToDoList.Domain.Commands
{
    public record InsertToDoItemCommand(string ItemTitle, string ItemDescription, string UserName) : IRequest<int>;
}
