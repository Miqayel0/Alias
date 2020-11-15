using MediatR;

namespace Alias.Application.Games.Queries.AddPage
{
    public class AddPageCommand : IRequest<int>
    {
        public int GameId { get; set; }
    }
}
