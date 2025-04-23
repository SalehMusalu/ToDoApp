using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using ToDoApp.Application.Exceptions;
using ToDoApp.Application.Queries.Handlers;
using ToDoApp.Application.Queries;
using ToDoApp.Domain.Repositories.ToDo;
using ToDoApp.Domain.Entities;

namespace ToDoApp.UnitTests.Application.QueryTest
{
    public class GetToDoItemHandlersTests
    {
        private readonly Mock<IToDoItemRepository> _mockRepository;

        public GetToDoItemHandlersTests()
        {
            _mockRepository = new Mock<IToDoItemRepository>();
        }

        [Fact]
        public async Task Handle_ShouldReturnToDoItemDTO_WhenItemExists()
        {
            // Arrange
            var id = Guid.NewGuid();
            var toDoItem = new ToDoItem("Test Title", "Test Description");

            _mockRepository.Setup(r => r.GetToDoItemById(id))
                .ReturnsAsync(toDoItem);

            var handler = new GetToDoItemHandlers(_mockRepository.Object);

            // Act
            var result = await handler.Handle(new GetToDoItem(id), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Title.Should().Be("Test Title");
            result.Description.Should().Be("Test Description");
        }

        [Fact]
        public async Task Handle_ShouldThrowNotFoundException_WhenItemDoesNotExist()
        {
            // Arrange
            var id = Guid.NewGuid();

            _mockRepository.Setup(r => r.GetToDoItemById(id))
                .ReturnsAsync((ToDoItem?)null);

            var handler = new GetToDoItemHandlers(_mockRepository.Object);

            // Act
            Func<Task> act = async () => await handler.Handle(new GetToDoItem(id), CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>();
        }
    }
}
