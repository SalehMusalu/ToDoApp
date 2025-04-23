using FluentAssertions;
using Moq;
using ToDoApp.Application.Commands;
using ToDoApp.Application.Commands.Handlers;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Factories;
using ToDoApp.Domain.Repositories.ToDo;

namespace ToDoApp.UnitTests.Application.CommandTest
{
    public class RemoveToDoItemHandlerTests
    {
        private readonly Mock<IToDoItemRepository> _mockRepository;
        private readonly Mock<IToDoItemFactory> _mockFactory;

        public RemoveToDoItemHandlerTests()
        {
            _mockRepository = new Mock<IToDoItemRepository>();
            _mockFactory = new Mock<IToDoItemFactory>();
        }

        [Fact]
        public async Task AddAndRemoveToDoItem_ShouldSucceed()
        {
            // Arrange
            var title = "Sample Task";
            var description = "Test Description";
            var id = Guid.NewGuid();
            var toDoItem = new ToDoItem(id, title, description);


            var addCommand = new AddToDoItem(title, description);
            var addHandler = new AddToDoItemHandler(_mockRepository.Object, _mockFactory.Object);

            _mockFactory.Setup(f => f.Create(
                addCommand.Title,
                addCommand.Description,
                ToDoStatus.Completed)).Returns(toDoItem);

            // Act
            var addedItem = await addHandler.Handle(addCommand, CancellationToken.None);

            _mockRepository.Setup(r => r.GetToDoByIdAndTitle(id, title))
                           .ReturnsAsync(toDoItem);

            var removeCommand = new RemoveToDoItem(id, title);
            var removeHandler = new RemoveToDoItemHandler(_mockRepository.Object);

            // Act
            var removeResult = await removeHandler.Handle(removeCommand, CancellationToken.None);

            // Assert
            removeResult.Should().BeTrue();
            _mockRepository.Verify(r => r.RemoveAsync(toDoItem), Times.Once);
        }

    }
}
