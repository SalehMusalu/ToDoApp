using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Domain.Factories
{
    public interface IToDoItemFactory
    {
        ToDoItem Create(string title, string description, ToDoStatus status);
        ToDoItem Update(Guid id, string title, string description, ToDoStatus status);
    }
}
