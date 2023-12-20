using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Domain.Commands;

namespace ToDoList.Domain.Handlers.Commends
{
    public class UpdateToDoListItemHandler : IRequestHandler<UpdateToDoItemCommand, int>
    {
        private readonly AppDbContext _appDbContext;
        public UpdateToDoListItemHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var listItems = _appDbContext.Items.Include(item => item.User).ToList();
            var item = listItems.FirstOrDefault(item => item.ItemId == request.Id && item.User?.UserName == request.UserName.ToString()) ?? throw new NotImplementedException();
            item.ItemTitle = request.ItemTitle;
            item.ItemDescription = request.ItemDescription;
            item.IsCompleted = request.isCompleted;
            item.CompletionDate = request.completionDate;
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
