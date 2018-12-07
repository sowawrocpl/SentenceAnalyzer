using System.Collections.Generic;

namespace SentenceAnalyzer.BusinessLogic.Abstraction
{
    public interface ITextAnalyzer
    {
        IDictionary<string, int> CountWords(string sentence);
    }
}
