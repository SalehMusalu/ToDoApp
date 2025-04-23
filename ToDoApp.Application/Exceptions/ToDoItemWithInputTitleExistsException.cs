using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Exceptions;

namespace ToDoApp.Application.Exceptions
{
    public class ToDoItemWithInputTitleExistsException : PersonManagementException
    {
        public ToDoItemWithInputTitleExistsException() : base("ToDoItem Title Is Exists")
        {
        }
    }
}
