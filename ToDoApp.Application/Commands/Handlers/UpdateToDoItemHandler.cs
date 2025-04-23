using FluentValidation;
using MediatR;
using ToDoApp.Application.Exceptions;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Factories;
using ToDoApp.Domain.Repositories.ToDo;

namespace ToDoApp.Application.Commands.Handlers
{
    internal class UpdateToDoItemHandler : IRequestHandler<UpdateToDoItem, bool>
    {
        private readonly IToDoItemRepository _repository;
        private readonly IToDoItemFactory _factory;

        public UpdateToDoItemHandler(IToDoItemRepository repository, IToDoItemFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<bool> Handle(UpdateToDoItem request, CancellationToken cancellationToken)
        {

            var toDoItem = await _repository.GetAsync(request.Id);
            if (toDoItem == null)
            {
                throw new ToDoItemNotFoundException();
            }



            var newtoDoItem = _factory.Update(toDoItem.Id,request.Title, request.Description, ToDoStatus.Completed);

            await _repository.UpdateAsync(newtoDoItem);

            return true;
        }
    }
}
