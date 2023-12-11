using ToDoList.Persistence.Entities;

namespace ToDoList.Api.Contracts
{
    public interface IToDoListService
    {
        Task<IEnumerable<ToDoListItem>> GetItems(string userName);
    }
}
