using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Factories;

namespace ToDoApp.UnitTests.Domain
{
        public class ToDoItemTests
        {
        private readonly IToDoItemFactory _factory;

        public ToDoItemTests()
        {
            _factory = new ToDoItemFactory();
        }

        [Fact]
            public void Create_Should_Return_ToDoItem_With_Pending_Status_By_Default()
            {
                // Arrange
                var title = "Test Task";
                var description = "This is a test";

                // Act
                var item = _factory.Create(title, description, ToDoStatus.Pending);

                // Assert
                item.ShouldNotBeNull();
                item.Title.ShouldBe(title);
                item.Description.ShouldBe(description);
                item.Status.ShouldBe(ToDoStatus.Pending);
            }

            [Fact]
            public void Create_Should_Set_Status_To_Completed_When_Requested()
            {
                // Arrange
                var title = "Completed Task";
                var description = "Task already done";

                // Act
                var item = _factory.Create(title, description, ToDoStatus.Completed);

                // Assert
                item.Status.ShouldBe(ToDoStatus.Completed);
            }

            [Fact]
            public void Create_Should_Throw_When_Title_Is_Empty()
            {
                // Act
                var exception = Record.Exception(() =>
                    _factory.Create("", "desc", ToDoStatus.Pending));

                // Assert
                exception.ShouldNotBeNull();
                exception.ShouldBeOfType<ArgumentException>();
            }
        
            [Fact]
            public void MarkAsCompleted_Should_Change_Status()
            {
                var item = _factory.Create("Test", "Test", ToDoStatus.Pending);

                item.MarkAsCompleted();

                item.Status.ShouldBe(ToDoStatus.Completed);
            }
        }
    }