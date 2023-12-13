using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Domain.Queries;
using ToDoList.Persistence.Entities;

namespace ToDoList.Domain.Handlers.Queries
{
    public class GetToDoItemByIdHandler : IRequestHandler<GetToDoItemsByIdQuery, ToDoListItem?>
    {
        private readonly AppDbContext _appDbContext;
        public GetToDoItemByIdHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        // Hint this work around, I did it this way attentionally as FirstOrDefaultAsync Doesn't work as expected with SQLLite. It needs deeper investigation 
        public Task<ToDoListItem?> Handle(GetToDoItemsByIdQuery request, CancellationToken cancellationToken)
        {
            var listItems = _appDbContext.Items.AsNoTracking().Include(item => item.User).ToList();
            var result = listItems.FirstOrDefault(item => item.ItemId == request.itemId && item.User?.UserName == request.userName.ToString());

            return Task.FromResult(result);
        }
    }
}
