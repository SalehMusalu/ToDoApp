using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Exceptions;

namespace ToDoApp.Application.Exceptions
{
    internal class ToDoItemNotFoundException : PersonManagementException
    {
        public ToDoItemNotFoundException() : base("ToDoItem Not Found")
        {
        }
    }
}
