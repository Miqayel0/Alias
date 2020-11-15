using Alias.Application.Games.Commands.Create;
using MediatR;
using System.Collections.Generic;

namespace Alias.Application.Games.Queries.Create
{
    public class CreateGameCommand : IRequest<CreateGameResult>
    {
        public int Score { get; set; }
        public int Interval { get; set; }
        public IEnumerable<string> Teams { get; set; }
    }
}
