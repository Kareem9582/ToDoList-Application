using MediatR;
using Moq;
using Moq.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Domain.Commands;
using ToDoList.Domain.Handlers.Commends;
using ToDoList.Tests.Database;

namespace ToDoList.Tests.Domain.Handlers
{
    public class CommandsHandlersTests
    {
        private readonly Mock<AppDbContext> appDbContextMock;
        public CommandsHandlersTests()
        {
            var cancellationToken = new CancellationToken();
            appDbContextMock = new Mock<AppDbContext>();
            appDbContextMock.Setup(x => x.Items)
                .ReturnsDbSet(FakeDatabase.GetFakeItems());
            appDbContextMock.Setup(x => x.Users)
                .ReturnsDbSet(FakeDatabase.GetFakeUsers());
            appDbContextMock.Setup(c => c.SaveChangesAsync(cancellationToken)).ReturnsAsync(1);

        }
        [Fact]
        public void InsertToDoListItem()
        {
            var mediator = new Mock<IMediator>();

            var command = new InsertToDoItemCommand("Unit Test", "Unit Test Description", "Kareem@UnitTest");
            var handler = new InsertToDoListItemHandler(appDbContextMock.Object);

            //Act
            var commandHanlderResult = handler.Handle(command, new CancellationToken()).Result;

            //Assert
            Assert.Equal(1, commandHanlderResult);
        }
    }
}