using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;

namespace Alias.Domain.Entities.TeamAggregat
{
    public class Game : EntityBase
    {
        public int Score { get; private set; }

        /// <summary>
        /// interval by ml seconds
        /// </summary>
        public double Interval { get; private set; }

        public bool IsFinished { get; private set; }

        public DateTime FinishedAt { get; private set; }

        public IReadOnlyCollection<TeamGame> TeamGames => _teamGames.AsReadOnly();

        public Game(int score, double interval, IEnumerable<Team> teams)
        {
            Guard.Against.OutOfRange(score, nameof(score), 10, 1000);
            Guard.Against.OutOfRange(interval, nameof(interval), 10, 1000000);

            Score = score;
            Interval = interval;
            AddTeams(teams);
        }

        void AddTeams(IEnumerable<Team> teams)
        {
            bool turn = true;
            foreach (var team in teams)
            {
                _teamGames.Add(new TeamGame(turn, team));
                turn = false;
            }
        }

        public void FinishGame()
        {
            IsFinished = true;
        }

        public Game()
        {
        }

        #region Private fields

        private readonly List<TeamGame> _teamGames = new List<TeamGame>();

        #endregion Private fields
    }
}
