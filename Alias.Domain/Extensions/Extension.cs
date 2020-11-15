using Alias.Domain.Exceptions;

namespace Alias.Domain.Entities
{
    public static class Extension
    {
        public static void CheckForNull<TEntity>(this TEntity entity) where TEntity : EntityBase
        {
            if (entity == null)
                throw new SmartException($"{typeof(TEntity).Name} not found");
        }
    }
}
