using System.Collections.Generic;

namespace SentenceAnalyzer.BusinessLogic.Abstraction
{
    public interface ITextSplitter
    {
        IEnumerable<string> Split(string sentence);
    }
}
