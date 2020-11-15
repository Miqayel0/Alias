using Alias.Application.Games.Commands.Create;
using Alias.Domain.Entities.TeamAggregat;
using Alias.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alias.Application.Games.Queries.Create
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, CreateGameResult>
    {
        private readonly IRepository _repository;
        public CreateGameCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateGameResult> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = new Game(request.Score, request.Interval, request.Teams.Select(x => new Team(x)));

            await _repository.Create(game);
            await _repository.CompleteAsync(cancellationToken);

            return new CreateGameResult
            {
                GameId = game.Id,
                TeamGames = game.TeamGames.Select(x => new TeamGameResult { Id = x.Id, Turn = x.Turn })
            };
        }
    }
}
