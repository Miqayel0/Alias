using Alias.Domain.Entities;
using Alias.Domain.Entities.TeamAggregat;
using Alias.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alias.Application.Games.Queries.MarkeWord
{
    public class MarkeWordCommandHandler : IRequestHandler<MarkeWordCommand, bool>
    {
        private readonly IRepository _repository;
        public MarkeWordCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(MarkeWordCommand request, CancellationToken cancellationToken)
        {
            var teamGame = await _repository.Filter<TeamGame>(x => x.GameId == request.GameId && x.Turn, i => i.Game).FirstOrDefaultAsync(cancellationToken);
            teamGame.CheckForNull();

            var pageWord = await _repository.Filter<Page>(x => x.TeamGameId == teamGame.Id && x.CreatedDt.AddMilliseconds(teamGame.Game.Interval) >= DateTime.UtcNow)
                .Select(x => x.PageWords.FirstOrDefault(z => z.Id == request.PageWordId))
                .FirstOrDefaultAsync(cancellationToken);

            var teamGames = await _repository.Filter<TeamGame>(x => x.GameId == request.GameId).AsNoTracking().ToListAsync(cancellationToken);
            var lastTeamGame = teamGames.LastOrDefault();

            if (lastTeamGame.Id == teamGame.Id && (lastTeamGame.Score + 1 >= teamGame.Game.Score || teamGames.Any(x => x.Score >= teamGame.Game.Score)))
            {
                teamGame.Game.FinishGame();
            }

            pageWord.CheckForNull();
            pageWord.Mark();
            teamGame.AddScore();

            await _repository.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
