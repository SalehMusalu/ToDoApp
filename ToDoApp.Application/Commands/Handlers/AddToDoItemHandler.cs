using FluentValidation;
using MediatR;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Exceptions;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Factories;
using ToDoApp.Domain.Repositories.ToDo;
using static ToDoApp.Application.Mappers.ToDoItemMapper;

namespace ToDoApp.Application.Commands.Handlers
{
    internal class AddToDoItemHandler : IRequestHandler<AddToDoItem, ToDoItemDTO>
    {
        private readonly IToDoItemRepository _repository;
        private readonly IToDoItemFactory _factory;

        public AddToDoItemHandler(IToDoItemRepository repository, IToDoItemFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<ToDoItemDTO> Handle(AddToDoItem request, CancellationToken cancellationToken)
        {


            if (await _repository.IsToDoExistsByTitle(request.Title))
            {
                throw new ToDoItemWithInputTitleExistsException();
            }

            var toDoItem = _factory.Create(request.Title, request.Description, ToDoStatus.Completed);

            await _repository.AddAsync(toDoItem);


            return PersonMapper.Mapper.Map<ToDoItemDTO>(toDoItem);

        }
    }
}
