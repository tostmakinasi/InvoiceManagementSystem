﻿using FluentValidation;
using InvoiceManagement.Core.ViewModels;

namespace InvoiceManagement.Services.Validations
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(DefaultValidationMessages.NotEmptyMessage)
                .NotNull().WithMessage(DefaultValidationMessages.NotNullMessage)
                .EmailAddress().WithMessage("{PropertyName} isn't an email!");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(DefaultValidationMessages.NotEmptyMessage)
                .NotNull().WithMessage(DefaultValidationMessages.NotNullMessage);

            RuleFor(x => x.IdentificationNumber)
               .NotEmpty().WithMessage(DefaultValidationMessages.NotEmptyMessage)
               .NotNull().WithMessage(DefaultValidationMessages.NotNullMessage).Length(11).WithMessage("{PropertyName} must be 11 digits!");
        }
    }
}
