using Moq;
using Moq.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Domain.Handlers.Queries;
using ToDoList.Domain.Queries;
using ToDoList.Tests.Database;

namespace ToDoList.Tests.Domain.Handlers
{
    public class QueriesHandlersTests
    {
        private readonly Mock<AppDbContext> appDbContextMock;

        public QueriesHandlersTests()
        {
            appDbContextMock = new Mock<AppDbContext>();
            appDbContextMock.Setup(x => x.Items)
                .ReturnsDbSet(FakeDatabase.GetFakeItems());
            appDbContextMock.Setup(x => x.Users)
                .ReturnsDbSet(FakeDatabase.GetFakeUsers());

        }
        public void GetToDoListItems_ShouldReutrnOne()
        {
            var query = new GetToDoItemsListQuery("Kareem@UnitTest");
            var queryHandler = new GetToDoItemsListHandler(appDbContextMock.Object);
            var queryHanlderResult = queryHandler.Handle(query, new CancellationToken()).Result;
            Assert.Equal(1, queryHanlderResult?.Count());
        }
    }
}
