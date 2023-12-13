using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Domain.Queries;
using ToDoList.Persistence.Entities;

namespace ToDoList.Domain.Handlers.Queries
{
    public class GetToDoItemsListHandler : IRequestHandler<GetToDoItemsListQuery, IEnumerable<ToDoListItem>>
    {
        private readonly AppDbContext _appDbContext;
        public GetToDoItemsListHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<ToDoListItem>> Handle(GetToDoItemsListQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.Items.Where(item => item.User.UserName == request.userName.ToString()).ToListAsync();
        }
    }
}
