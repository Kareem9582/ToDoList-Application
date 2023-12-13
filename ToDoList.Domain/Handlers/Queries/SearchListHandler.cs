using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
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
            return await _appDbContext.Items.Where(conditions).ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
