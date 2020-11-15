using FluentValidation;

namespace Alias.Application.Games.Queries.Create
{
    public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
    {
        public CreateGameCommandValidator()
        {
            RuleFor(x => x.Score).GreaterThanOrEqualTo(10).LessThanOrEqualTo(1000);
            RuleFor(x => x.Interval).GreaterThanOrEqualTo(10000).LessThanOrEqualTo(1000000);
            RuleForEach(x => x.Teams).NotEmpty();
        }
    }
}
