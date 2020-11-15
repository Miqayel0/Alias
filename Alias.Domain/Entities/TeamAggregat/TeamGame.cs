using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Linq;

namespace Alias.Domain.Entities.TeamAggregat
{
    public class TeamGame : EntityBase
    {
        public int Score { get; private set; }
        public bool Turn { get; private set; }
        public int GameId { get; private set; }
        public int TeamId { get; private set; }
        public Game Game { get; private set; }
        public Team Team { get; private set; }

        public IReadOnlyCollection<Page> Pages => _pages.AsReadOnly();


        public TeamGame(bool turn, Team team)
        {
            Guard.Against.Null(team, nameof(Team));
            Team = team;
            Turn = turn;
        }

        public TeamGame()
        {
        }

        public void AddPage(List<int> wordIds)
        {
            if (wordIds.Any())
            {
                var page = new Page();
                wordIds.ForEach(x => page.AddWord(x));
                _pages.Add(page);
            }
        }

        public void AddScore()
        {
            ++Score;
        }

        public void SetTurn()
        {
            Turn = true;
        }

        public void RemoveTurn()
        {
            Turn = false;
        }

        #region Private fields

        private readonly List<Page> _pages = new List<Page>();

        #endregion Private fields
    }
}
