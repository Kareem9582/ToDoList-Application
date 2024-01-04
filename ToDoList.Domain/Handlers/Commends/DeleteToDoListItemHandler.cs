using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Domain.Commands;

namespace ToDoList.Domain.Handlers.Commends
{
    public class DeleteToDoListItemHandler : IRequestHandler<DeleteToDoItemCommand, int>
    {
        private readonly AppDbContext _appDbContext;
        public DeleteToDoListItemHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            var listItems = _appDbContext.Items.Include(item => item.User).ToList();
            Persistence.Entities.ToDoListItem? item = listItems.FirstOrDefault(item => item.ItemId == request.Id && item.User?.UserName == request.UserName.ToString());
            if(item == null)
                return 0;
            _appDbContext.Items.Remove(item);
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
