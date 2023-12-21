using MediatR;
using ToDoList.Context;
using ToDoList.Domain.Commands;
using ToDoList.Persistence.Entities;

namespace ToDoList.Domain.Handlers.Commends
{
    public class InsertToDoListItemHandler : IRequestHandler<InsertToDoItemCommand, int>
    {
        private readonly AppDbContext _appDbContext;
        public InsertToDoListItemHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(InsertToDoItemCommand request, CancellationToken cancellationToken)
        {
            var user = _appDbContext.Users.FirstOrDefault(x => x.UserName == request.UserName);
            if (user == null)
                return 0;
            var result = _appDbContext.Items.AddAsync(new ToDoListItem { 
                UserId = user.Id,
                ItemId = Guid.NewGuid(),
                IsCompleted = false,
                ItemDescription = request.ItemDescription,
                ItemTitle = request.ItemTitle,
                User = null
            });

           return await _appDbContext.SaveChangesAsync();
        }
    }
}
