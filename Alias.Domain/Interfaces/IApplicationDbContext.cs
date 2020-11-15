using Alias.Domain.Entities;
using Alias.Domain.Entities.TeamAggregat;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alias.Domain.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Team> Teams { get; set; }
        DbSet<Page> Pages { get; set; }
        DbSet<PageWord> PageWords { get; set; }
        DbSet<TeamGame> TeamGames { get; set; }
        DbSet<Game> Games { get; set; }
        DbSet<Word> Words { get; set; }

        DbSet<TEntity> WriterSet<TEntity>() where TEntity : EntityBase;
        IQueryable<TEntity> ReaderSet<TEntity>() where TEntity : EntityBase;
        Task<int> SaveChangesAsync(CancellationToken token = default);
        int SaveChanges();
    }
}
