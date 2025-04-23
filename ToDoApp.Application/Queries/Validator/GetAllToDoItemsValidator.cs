using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ToDoApp.Application.Queries.Validator
{
    public class GetAllToDoItemsValidator : AbstractValidator<GetAllToDoItems>
    {
        public GetAllToDoItemsValidator()
        {
            
        }
    }
}
