using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Domain.Helpers;
using ToDoList.Domain.Queries;
using ToDoList.Persistence.Entities;

namespace ToDoList.Domain.Handlers.Queries
{
    public class SearchListHandler : IRequestHandler<SearchListQuery, IEnumerable<ToDoListItem>>
    {
        private readonly AppDbContext _appDbContext;
        public SearchListHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<ToDoListItem>> Handle(SearchListQuery request, CancellationToken cancellationToken)
        {
            var conditions = FilterBuilderHelper.BuildCondition(request.filter);
            return await _appDbContext.Items.AsNoTracking().Where(conditions).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
