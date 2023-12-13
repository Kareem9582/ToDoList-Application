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
        private readonly Mock<AppDbContext> AppDbContextMock;
        public CommandsHandlersTests()
        {
            var cancellationToken = new CancellationToken();
            AppDbContextMock = new Mock<AppDbContext>();
            AppDbContextMock.Setup(x => x.Items)
                .ReturnsDbSet(FakeDatabase.GetFakeItems());
            AppDbContextMock.Setup(x => x.Users)
                .ReturnsDbSet(FakeDatabase.GetFakeUsers());
            AppDbContextMock.Setup(c => c.SaveChangesAsync(cancellationToken)).ReturnsAsync(1);

        }
        [Fact]
        public void InsertToDoListItem()
        {
            var mediator = new Mock<IMediator>();

            var command = new InsertToDoItemCommand("Unit Test", "Unit Test Description", "Kareem@UnitTest");
            var handler = new InsertToDoListItemHandler(AppDbContextMock.Object);

            //Act
            var commandHanlderResult = handler.Handle(command, new CancellationToken()).Result;

            //Assert
            Assert.Equal(1, commandHanlderResult);
            AppDbContextMock.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}