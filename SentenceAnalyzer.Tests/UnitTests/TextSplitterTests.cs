using NUnit.Framework;
using SentenceAnalyzer.BusinessLogic.Abstraction;
using SentenceAnalyzer.BusinessLogic.Implementation;

namespace SentenceAnalyzer.Tests.UnitTests
{
    [TestFixture]
    public class TextSplitterTests
    {
        private ITextSplitter _splitter;

        [SetUp]
        public void SetUp()
        {
            _splitter = new TextSplitter();
        }


        [Test]
        public void SplitTest1()
        {
            // arrange
            var text = "This is a statement, and so is this.";
            
            // act
            var words = _splitter.Split(text);

            // assert
            CollectionAssert.AreEquivalent(new [] {"this", "is", "a", "statement", "and", "so", "is", "this"}, words);
        }


        [Test]
        public void SplitTest2()
        {
            // arrange
            var text = ".,;! ";

            // act
            var words = _splitter.Split(text);

            // assert
            CollectionAssert.IsEmpty(words);
        }

        [Test]
        public void SplitTest3()
        {
            // act
            var words = _splitter.Split(null);

            // assert
            CollectionAssert.IsEmpty(words);
        }
    }
}
