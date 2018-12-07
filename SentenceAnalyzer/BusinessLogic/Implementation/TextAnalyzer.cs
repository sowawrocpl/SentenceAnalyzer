using System.Collections.Generic;
using SentenceAnalyzer.BusinessLogic.Abstraction;

namespace SentenceAnalyzer.BusinessLogic.Implementation
{
    public class TextAnalyzer : ITextAnalyzer
    {
        private readonly ITextSplitter _splitter;
        private readonly IWordCounter _counter;

        public TextAnalyzer(ITextSplitter splitter, IWordCounter counter)
        {
            _splitter = splitter;
            _counter = counter;
        }


        public IDictionary<string, int> CountWords(string sentence)
        {
            var words = _splitter.Split(sentence);
            return _counter.Count(words);
        }
    }
}
