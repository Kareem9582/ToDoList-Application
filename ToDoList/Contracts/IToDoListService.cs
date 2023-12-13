using ToDoList.Api.Models;
using ToDoList.Domain.Objects;

namespace ToDoList.Api.Contracts
{
    public interface IToDoListService
    {
        Task<IEnumerable<GetItemModel>> GetItems(string userName);
        Task<GetItemModel> GetItemById(Guid itemId, string userName);
        Task<int> Insert(string itemTitle, string itemDescription, string userName);
        Task<int> Update(Guid id, string itemTitle, string itemDescription, string userName);
        Task<int> Delete(Guid id, string userName);
        Task<int> MarkAsComplete(Guid id, string userName);
        Task<IEnumerable<GetItemModel>> Search(Filter filter, string userName);
    }
}
