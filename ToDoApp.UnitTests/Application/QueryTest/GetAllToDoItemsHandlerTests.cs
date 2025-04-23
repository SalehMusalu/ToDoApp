using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ToDoApp.Application.Queries.Handlers;
using ToDoApp.Application.Queries;
using ToDoApp.Domain.Repositories.ToDo;
using ToDoApp.Domain.Entities;
using FluentAssertions;

namespace ToDoApp.UnitTests.Application.QueryTest
{
    public class GetAllToDoItemsHandlerTests
    {
        private readonly Mock<IToDoItemRepository> _mockRepository;

        public GetAllToDoItemsHandlerTests()
        {
            _mockRepository = new Mock<IToDoItemRepository>();
        }

        [Fact]
        public async Task Handle_ShouldReturnMappedToDoItemDTOs()
        {
            // Arrange
            var toDoItems = new List<ToDoItem>
            {
                new ToDoItem(Guid.NewGuid(),"Task1", "Description1"),
                new ToDoItem(Guid.NewGuid(), "Task2", "Description2")
            };

            _mockRepository.Setup(r => r.GetAllToDoItem())
                .ReturnsAsync(toDoItems);

            var handler = new GetAllToDoItemsHandler(_mockRepository.Object);

            // Act
            var result = await handler.Handle(new GetAllToDoItems(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result[0].Title.Should().Be("Task1");
            result[1].Description.Should().Be("Description2");
        }

        [Fact]
        public async Task Handle_WhenNoItemsExist_ShouldReturnEmptyList()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetAllToDoItem())
                .ReturnsAsync(new List<ToDoItem>());

            var handler = new GetAllToDoItemsHandler(_mockRepository.Object);

            // Act
            var result = await handler.Handle(new GetAllToDoItems(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }
    }
}
