using FluentValidation;
using ReadingIsGood.Entities.DTOs;

namespace ReadingIsGood.Business.ValidationRules.FluentValidation
{
    public class BookValidator : AbstractValidator<AddBookDto>
    {
        public BookValidator()
        {
            RuleFor(x => x.AuthorId).NotEmpty();

            RuleFor(x => x.CategoryIds).NotEmpty()
                .NotNull();

            RuleFor(x => x.Description).NotEmpty()
                .Length(25, 500);

            RuleFor(x => x.ISBN).NotEmpty()
                .Length(13, 13);

            RuleFor(x => x.Name).NotEmpty()
                .Length(1, 50);

            RuleFor(x => x.Pages).NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.ReorderLevel).NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.UnitsInStock).NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.UnitPrice).NotEmpty()
                .GreaterThan(0m);

            RuleFor(x => x.YearOfPublication).NotEmpty();
        }
    }
}
