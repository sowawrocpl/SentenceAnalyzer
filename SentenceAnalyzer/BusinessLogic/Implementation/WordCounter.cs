using System.Collections.Generic;
using System.Linq;
using SentenceAnalyzer.BusinessLogic.Abstraction;

namespace SentenceAnalyzer.BusinessLogic.Implementation
{
    public class WordCounter : IWordCounter
    {
        public IDictionary<string, int> Count(IEnumerable<string> words)
        {
            return words?.GroupBy(x => x).ToDictionary(key => key.Key, v => v.Count());
        }
    }
}
