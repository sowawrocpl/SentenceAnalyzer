using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SentenceAnalyzer.BusinessLogic.Abstraction;

namespace SentenceAnalyzer.BusinessLogic.Implementation
{
    public class TextSplitter : ITextSplitter
    {
        public IEnumerable<string> Split(string sentence)
        {
            var cleanText = Regex.Replace(sentence ?? String.Empty, @"\p{P}", "");
            return cleanText
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower());
        }
    }
}
