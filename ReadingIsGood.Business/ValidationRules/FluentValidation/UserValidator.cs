using FluentValidation;
using ReadingIsGood.Entities.DTOs;

namespace ReadingIsGood.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).EmailAddress()
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Password)
                .MinimumLength(7)
                .MaximumLength(30)
                .NotNull()
                .NotEmpty();

            
        }
    }
}
