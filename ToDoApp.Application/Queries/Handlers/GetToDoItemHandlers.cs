using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using ToDoApp.Application.Commands;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Exceptions;
using ToDoApp.Domain.Factories;
using ToDoApp.Domain.Repositories.ToDo;
using static ToDoApp.Application.Mappers.ToDoItemMapper;

namespace ToDoApp.Application.Queries.Handlers
{
    public class GetToDoItemHandlers : IRequestHandler<GetToDoItem, ToDoItemDTO>
    {
        private readonly IToDoItemRepository _repository;

        public GetToDoItemHandlers(IToDoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<ToDoItemDTO> Handle(GetToDoItem request, CancellationToken cancellationToken)
        {

            var toDoItem = await _repository.GetToDoItemById(request.Id);

            if (toDoItem == null)
            {
                throw new KeyNotFoundException("ToDo item not found.");
            }

            return PersonMapper.Mapper.Map<ToDoItemDTO>(toDoItem);
        }
    }
}
