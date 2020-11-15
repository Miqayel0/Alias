using Alias.Domain.Entities;
using Alias.Domain.Entities.TeamAggregat;
using Alias.Domain.Exceptions;
using Alias.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alias.Application.Games.Queries.AddPage
{
    public class AddPageCommandHandler : IRequestHandler<AddPageCommand, int>
    {
        private readonly IRepository _repository;
        public AddPageCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AddPageCommand request, CancellationToken cancellationToken)
        {
            var teamGame = await _repository
                .Filter<TeamGame>(x => x.GameId == request.GameId && x.Turn, i => i.Game, i => i.Pages)
                .FirstOrDefaultAsync(cancellationToken);

            teamGame.CheckForNull();

            double interval = teamGame.Game.Interval;

            if (teamGame.Game.IsFinished)
                throw new SmartException("Game was finished");

            if (teamGame.Pages.All(x =>x.CreatedDt.AddMilliseconds(interval) < DateTime.UtcNow))
            {
                teamGame.RemoveTurn();
                var others = await _repository
                    .Filter<TeamGame>(x => x.GameId == request.GameId)
                    .ToListAsync(cancellationToken);

                if (others is null || !others.Any())
                    throw new SmartException("Other cannot be null or empty");

                int indx = others.FindIndex(x => x.Id == teamGame.Id);
                var nextTeamGame = others.ElementAtOrDefault(indx + 1) ?? others[0];
                nextTeamGame.SetTurn();
            }

            if (!teamGame.Turn && teamGame.Score >= teamGame.Game.Score)
                throw new SmartException("Invalid operation");

            var wordsNotBe = await _repository.Filter<Game>(x => x.Id == teamGame.GameId)
                .AsNoTracking()
                .SelectMany(x => x.TeamGames)
                .SelectMany(x => x.Pages)
                .SelectMany(x => x.PageWords)
                .Select(x => x.WordId)
                .ToListAsync(cancellationToken);

            var words = await _repository.Filter<Word>(x => !wordsNotBe.Contains(x.Id))
                .Take(7)
                .AsNoTracking()
                .Select(x => x.Id)
                .ToListAsync(cancellationToken);

            teamGame.AddPage(words);

            await _repository.CompleteAsync(cancellationToken);
            return teamGame.Pages.First().Id;
        }
    }
}
