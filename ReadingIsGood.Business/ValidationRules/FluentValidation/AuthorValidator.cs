using FluentValidation;
using ReadingIsGood.Business.Constants;
using ReadingIsGood.Entities.DTOs;
using System;

namespace ReadingIsGood.Business.ValidationRules.FluentValidation
{
    public class AuthorValidator : AbstractValidator<UpdateAuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.Id)
                .Must(ValidateGuid)
                .WithErrorCode(Messages.EntityIdIsNotValid);


            RuleFor(x => x.ModifiedFirstName)
                .NotEmpty()
                .Length(2, 25);


            RuleFor(x => x.ModifiedLastName)
                .NotEmpty()
               .Length(2, 25);

        }

        private bool ValidateGuid(string unTrustedString)
        {
            return Guid.TryParse(unTrustedString, out var result);
        }
    }
}
