using MediatR;

namespace ToDoApp.Application.Commands
{
    public record RemoveToDoItem(Guid Id, string Title) : IRequest<bool>;
}
