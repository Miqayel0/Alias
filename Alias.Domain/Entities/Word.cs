using Alias.Domain.Interfaces;
using Ardalis.GuardClauses;

namespace Alias.Domain.Entities
{
    public class Word : EntityBase, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Language { get; private set; }

        public Word(string name, string language)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.NullOrWhiteSpace(language, nameof(language));
            Name = name;
            Language = language;
        }

        public Word()
        {
        }
    }
}
