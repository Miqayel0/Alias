using MediatR;

namespace Alias.Application.Games.Queries.MarkeWord
{
    public class MarkeWordCommand : IRequest<bool>
    {
        public int GameId { get; set; }
        public int PageWordId { get; set; }
    }
}
