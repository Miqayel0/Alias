using Ardalis.GuardClauses;

namespace Alias.Domain.Entities.TeamAggregat
{
    public class PageWord : EntityBase
    {
        public int WordId { get; private set; }
        public int PageId { get; private set; }
        public Word Word { get; private set; }
        public Page Page { get; private set; }
        public bool IsMarked { get; private set; }

        public PageWord(int wordId)
        {
            Guard.Against.NegativeOrZero(wordId, nameof(wordId));
            WordId = wordId;
        }

        public PageWord()
        {
        }

        public void Mark()
        {
            IsMarked = !IsMarked;
        }
    }
}
