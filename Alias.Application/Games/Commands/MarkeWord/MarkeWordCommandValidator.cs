using FluentValidation;

namespace Alias.Application.Games.Queries.MarkeWord
{
    public class MarkeWordCommandValidator : AbstractValidator<MarkeWordCommand>
    {
        public MarkeWordCommandValidator()
        {
            RuleFor(x => x.GameId).NotEmpty();
            RuleFor(x => x.PageWordId).NotEmpty();
        }
    }
}
