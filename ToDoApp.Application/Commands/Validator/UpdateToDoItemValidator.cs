using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ToDoApp.Application.Commands.Validator
{
    public class UpdateToDoItemValidator : AbstractValidator<UpdateToDoItem>
    {
        public UpdateToDoItemValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("شناسه معتبر نیست.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("عنوان نمی‌تواند خالی باشد.")
                .MaximumLength(100).WithMessage("عنوان نمی‌تواند بیشتر از 100 کاراکتر باشد.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("توضیحات نمی‌تواند بیشتر از 500 کاراکتر باشد.");
        }
    }
}
