using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ToDoApp.Application.Commands;

namespace ToDoApp.Application.Queries.Validator
{
    public class GetToDoItemValidator : AbstractValidator<GetToDoItem>
    {
        public GetToDoItemValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("شناسه معتبر نیست.");
        }
    }
}
