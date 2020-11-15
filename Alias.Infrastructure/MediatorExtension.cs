using Alias.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alias.infrastructure
{
    static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, IEnumerable<EntityEntry<EntityBase>> domainEntities, CancellationToken cancellationToken = default)
        {
            var domainEvents = domainEntities.SelectMany(x => x.Entity.DomainEvents);

            foreach (var entity in domainEntities)
            {
                entity.Entity.ClearDomainEvents();
            }

            var tasks = domainEvents.Select(domainEvent => mediator.Publish(domainEvent, cancellationToken));
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
