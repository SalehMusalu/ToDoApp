using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Exceptions;
using ToDoApp.Domain.Repositories.ToDo;
using static ToDoApp.Application.Mappers.ToDoItemMapper;

namespace ToDoApp.Application.Queries.Handlers
{
    public class GetAllToDoItemsHandler : IRequestHandler<GetAllToDoItems, List<ToDoItemDTO>>
    {
        private readonly IToDoItemRepository _repository;

        public GetAllToDoItemsHandler(IToDoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ToDoItemDTO>> Handle(GetAllToDoItems request, CancellationToken cancellationToken)
        {
            var toDoItem = await _repository.GetAllToDoItem();


            return PersonMapper.Mapper.Map<List<ToDoItemDTO>>(toDoItem);
        }
    }
}
