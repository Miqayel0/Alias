using System.Collections.Generic;

namespace Alias.Application.Games.Commands.Create
{
    public class CreateGameResult
    {
        public int GameId { get; set; }
        public IEnumerable<TeamGameResult> TeamGames { get; set; }
    }

    public class TeamGameResult
    {
        public int Id { get; set; }
        public bool Turn { get; set; }
    }
}
