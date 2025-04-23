using FluentAssertions;
using Moq;
using ToDoApp.Application.Commands;
using ToDoApp.Application.Commands.Handlers;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Factories;
using ToDoApp.Domain.Repositories.ToDo;

namespace ToDoApp.UnitTests.Application.CommandTest
{
    public class AddToDoItemHandlerTests
    {
        private readonly Mock<IToDoItemRepository> _mockRepository;
        private readonly Mock<IToDoItemFactory> _mockFactory;

        public AddToDoItemHandlerTests()
        {
            _mockRepository = new Mock<IToDoItemRepository>();
            _mockFactory = new Mock<IToDoItemFactory>();
        }

        [Fact]
        public async Task Handle_AddToDoItemCommand_ShouldReturnToDoItemWithCorrectTitle()
        {
            // Arrange
            var command = new AddToDoItem("Test Title", "GGG");

            var handler = new AddToDoItemHandler(_mockRepository.Object, _mockFactory.Object);

            var expectedToDoItem = new ToDoItem(command.Title, command.Description);

            _mockFactory.Setup(f => f.Create(
                command.Title,
                command.Description,
                ToDoStatus.Completed)).Returns(expectedToDoItem);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Title.Should().Be("Test Title");
        }


    }
}