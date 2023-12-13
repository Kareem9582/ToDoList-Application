using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Domain.Commands;

namespace ToDoList.Domain.Handlers.Commends
{
    public class MarkAsCompleteHandler : IRequestHandler<MarkAsCompleteCommand, int>
    {
        private readonly AppDbContext _appDbContext;
        public MarkAsCompleteHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(MarkAsCompleteCommand request, CancellationToken cancellationToken)
        {
            var listItems = _appDbContext.Items.Include(item => item.User).ToList();
            var item = listItems.FirstOrDefault(item => item.ItemId == request.Id && item.User?.UserName == request.UserName.ToString()) ?? throw new NotImplementedException();
            item.IsCompleted = true;
            item.CompletionDate = DateTime.Now;
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
