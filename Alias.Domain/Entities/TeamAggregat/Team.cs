using Alias.Domain.Interfaces;
using Ardalis.GuardClauses;
using System.Collections.Generic;

namespace Alias.Domain.Entities.TeamAggregat
{
    public class Team : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }

        public IReadOnlyCollection<TeamGame> TeamGames => _teamGames.AsReadOnly();

        public Team(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Name = name;
        }

        public Team()
        {
        }


        #region Private fields

        private readonly List<TeamGame> _teamGames = new List<TeamGame>();

        #endregion Private fields
    }
}
