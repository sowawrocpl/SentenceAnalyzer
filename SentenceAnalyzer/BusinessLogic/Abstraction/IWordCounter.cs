using System.Collections.Generic;

namespace SentenceAnalyzer.BusinessLogic.Abstraction
{
    public interface IWordCounter
    {
        IDictionary<string, int> Count(IEnumerable<string> words);
    }
}
