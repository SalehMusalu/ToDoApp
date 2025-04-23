using System.Net;
using System.Net.Http.Json;
using System.Text;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ToDoApp.API;
using ToDoApp.Application.Commands;
using ToDoApp.Application.DTOs;
using ToDoApp.Domain.Entities;
using ToDoApp.Infrastructure.Context;
using ToDoApp.Infrastructure.Migrations;
using ToDoItem = ToDoApp.Domain.Entities.ToDoItem;

namespace ToDoApp.UnitTests.API.Controllers
{
    public class ToDoControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ToDoControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetAll_ReturnsAllToDoItems()
        {
            // Arrange
            using var scope = _factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ToDoContext>();
            var client = _factory.CreateClient();

            dbContext.ToDoItems.RemoveRange(dbContext.ToDoItems);
            await dbContext.SaveChangesAsync();

            dbContext.ToDoItems.Add(new ToDoItem(Guid.NewGuid(), "Test 1", "Desc 1"));
            dbContext.ToDoItems.Add(new ToDoItem(Guid.NewGuid(), "Test 2", "Desc 2"));
            await dbContext.SaveChangesAsync();

            // Act
            var response = await client.GetAsync("/api/todo");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<List<ToDoItemDTO>>(content);
            items.Should().HaveCount(2);
            items.Should().Contain(x => x.Title == "Test 1");
            items.Should().Contain(x => x.Title == "Test 2");
        }

        [Fact]
        public async Task GetById_ReturnsCorrectItem()
        {
            // Arrange
            using var scope = _factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ToDoContext>();
            var client = _factory.CreateClient();

            var item = new ToDoItem(Guid.NewGuid(), "Test ById", "Desc");
            dbContext.ToDoItems.Add(item);
            await dbContext.SaveChangesAsync();

            // Act
            var response = await client.GetAsync($"/api/todo/{item.Id}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            var dto = JsonConvert.DeserializeObject<ToDoItemDTO>(content);
            dto.Title.Should().Be("Test ById");
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_IfItemDoesNotExist()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/api/todo/{Guid.NewGuid()}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Fact]
        public async Task Create_ReturnsCreatedItem()
        {
            // Arrange
            var client = _factory.CreateClient();
            var command = new AddToDoItem("New Task","Sample description");
            var json = JsonConvert.SerializeObject(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/todo", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var responseContent = await response.Content.ReadAsStringAsync();
            var createdItem = JsonConvert.DeserializeObject<ToDoItemDTO>(responseContent);
            createdItem.Title.Should().Be(command.Title);
            createdItem.Description.Should().Be(command.Description);
        }


        [Fact]
        public async Task Update_ReturnsNoContent_WhenItemExists()
        {
            // Arrange
            using var scope = _factory.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ToDoContext>();
            var item = new ToDoItem(Guid.NewGuid(), "Initial", "Update");

            await db.ToDoItems.AddAsync(item);
            await db.SaveChangesAsync();

            var client = _factory.CreateClient();
            var command = new UpdateToDoItem(item.Id, "Updated Task", "Updated Description");
            var json = JsonConvert.SerializeObject(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync("/api/todo/update", content);


            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenItemExists()
        {
            // Arrange
            using var scope = _factory.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ToDoContext>();
            var item = new ToDoItem("Task to Delete","jl");
            db.ToDoItems.Add(item);
            await db.SaveChangesAsync();

            var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync($"/api/todo/{item.Id}?title={item.Title}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }


    }
}