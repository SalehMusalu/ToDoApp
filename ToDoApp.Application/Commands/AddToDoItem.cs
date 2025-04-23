using MediatR;
using ToDoApp.Application.DTOs;

namespace ToDoApp.Application.Commands
{
    public record AddToDoItem(string Title, string Description) : IRequest<ToDoItemDTO>;
}
