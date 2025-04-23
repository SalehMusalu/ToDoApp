using MediatR;

namespace ToDoApp.Application.Commands
{
    public record UpdateToDoItem(Guid Id, string Title, string Description) : IRequest<bool>;
}
