using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Domain.Queries;
using ToDoList.Persistence.Entities;

namespace ToDoList.Domain.Handlers
{
    public class GetToDoItemsListHandler : IRequestHandler<GetToDoItemsListQuery, List<ToDoListItem>>
    {
        private readonly AppDbContext _appDbContext;
        public GetToDoItemsListHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<List<ToDoListItem>> Handle(GetToDoItemsListQuery request, CancellationToken cancellationToken)
        {
            return _appDbContext.Items.Where(item => item.User.UserName == request.userName.ToString()).ToListAsync();
        }
    }
}
