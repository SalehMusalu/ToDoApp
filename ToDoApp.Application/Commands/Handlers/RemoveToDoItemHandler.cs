using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using ToDoApp.Application.Exceptions;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Factories;
using ToDoApp.Domain.Repositories.ToDo;

namespace ToDoApp.Application.Commands.Handlers
{
    internal class RemoveToDoItemHandler : IRequestHandler<RemoveToDoItem, bool>
    {

        private readonly IToDoItemRepository _repository;

        public RemoveToDoItemHandler(IToDoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RemoveToDoItem request, CancellationToken cancellationToken)
        {

            var toDoItem = await _repository.GetToDoByIdAndTitle(request.Id,request.Title);
            if (toDoItem == null)
            {
                throw new ToDoItemNotFoundException();
            }

            await _repository.RemoveAsync(toDoItem);

            return true;



        }
    }
}
