using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ToDoApp.Application.DTOs;

namespace ToDoApp.Application.Queries
{
    public record GetAllToDoItems() : IRequest<List<ToDoItemDTO>>;
}
