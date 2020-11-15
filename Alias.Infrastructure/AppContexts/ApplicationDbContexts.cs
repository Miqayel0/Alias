using Alias.Domain.Entities;
using Alias.Domain.Entities.TeamAggregat;
using Alias.Domain.Interfaces;
using Alias.Domain.Identity;
using IdentityServer4.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Alias.infrastructure.AppContexts
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;

        public DbSet<Team> Teams { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageWord> PageWords { get; set; }
        public DbSet<TeamGame> TeamGames { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Word> Words { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            IIdentityService identityService = null, IMediator mediator = null) : base(options, operationalStoreOptions)
        {
            _identityService = identityService;
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<TEntity> WriterSet<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>();
        }

        public IQueryable<TEntity> ReaderSet<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>().AsQueryable();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<EntityBase>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            AddTimeStamp(entities);

            await _mediator.DispatchDomainEventsAsync(entities, cancellationToken).ConfigureAwait(false);

            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public void AddTimeStamp(IEnumerable<EntityEntry<EntityBase>> entities)
        {
            string currentUserId = _identityService.UserId;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.TrackAdd(currentUserId, DateTime.UtcNow);
                }

                entity.Entity.TrackEdit(currentUserId, DateTime.UtcNow);
            }
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}

