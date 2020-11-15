using System.Collections.Generic;

namespace Alias.Domain.Entities.TeamAggregat
{
    public class Page : EntityBase
    {
        public int TeamGameId { get; set; }
        public TeamGame TeamGame { get; set; }
        public IReadOnlyCollection<PageWord> PageWords => _pageWords.AsReadOnly();

        public void AddWord(int wordId)
        {
            if (wordId > 0)
            {
                _pageWords.Add(new PageWord(wordId));
            }
        }

        public Page()
        {
        }

        #region Private fields

        private readonly List<PageWord> _pageWords = new List<PageWord>();

        #endregion Private fields
    }
}
