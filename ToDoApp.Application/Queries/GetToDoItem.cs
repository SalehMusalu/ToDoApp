using MediatR;
using ToDoApp.Application.DTOs;

namespace ToDoApp.Application.Queries
{
    public record GetToDoItem(Guid Id) : IRequest<ToDoItemDTO>;
}
