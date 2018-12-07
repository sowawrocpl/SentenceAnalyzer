using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SentenceAnalyzer.BusinessLogic.Abstraction;
using SentenceAnalyzer.BusinessLogic.Implementation;
using SimpleInjector;
using Moq;

namespace SentenceAnalyzer.Tests.UnitTests
{
    [TestFixture]
    public class TextAnalyzerTests
    {
        private ITextAnalyzer _analyzer;

        private Mock<ITextSplitter> _splitterMock;
        private Mock<IWordCounter> _counterMock;

        private IDictionary<string, int> _counterResult;
        private IEnumerable<string> _arrayInTheMiddle;

        [SetUp]
        public void SetUp()
        {
            _arrayInTheMiddle = new[] {"a", "b", "c"};
            _splitterMock = new Mock<ITextSplitter>();
            _splitterMock.Setup(x => x.Split("a b c")).Returns(_arrayInTheMiddle);
      
            _counterResult = _arrayInTheMiddle.ToDictionary(key => key, value => 1);
            _counterMock = new Mock<IWordCounter>();
            _counterMock.Setup(x => x.Count(_arrayInTheMiddle)).Returns(_counterResult);
          
            var container = new Container();
            container.Register<ITextAnalyzer, TextAnalyzer>();
            container.RegisterInstance(_splitterMock.Object);
            container.RegisterInstance(_counterMock.Object);
            _analyzer = container.GetInstance<ITextAnalyzer>();
        }

        [Test]
        public void CountWordsTest1()
        {
            // arrange
            var input = "a b c";

            // act
            var output = _analyzer.CountWords(input);

            // assert
            _splitterMock.Verify(x => x.Split(input), Times.Once);
            _counterMock.Verify(x => x.Count(_arrayInTheMiddle), Times.Once);
            CollectionAssert.AreEquivalent(_counterResult, output);
        }
    }
}
