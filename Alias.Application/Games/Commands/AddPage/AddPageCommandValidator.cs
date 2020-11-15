using FluentValidation;

namespace Alias.Application.Games.Queries.AddPage
{
    public class AddPageCommandValidator : AbstractValidator<AddPageCommand>
    {
        public AddPageCommandValidator()
        {
            RuleFor(x => x.GameId).NotEmpty();
        }
    }
}
