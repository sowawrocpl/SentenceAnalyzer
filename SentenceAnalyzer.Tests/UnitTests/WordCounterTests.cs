using NUnit.Framework;
using SentenceAnalyzer.BusinessLogic.Abstraction;
using SentenceAnalyzer.BusinessLogic.Implementation;

namespace SentenceAnalyzer.Tests.UnitTests
{
    [TestFixture]
    public class WordCounterTests
    {
        private IWordCounter _counter;

        [SetUp]
        public void SetUp()
        {
            _counter = new WordCounter();
        }


        [Test]
        public void CountTest1()
        {
            // arrange
            var words = new[] { "zombie", "zombie", "zombie" };

            // act
            var dictionary = _counter.Count(words);

            // assert  
            Assert.AreEqual(1, dictionary.Count);
            Assert.AreEqual(3, dictionary["zombie"]);
        }

        [Test]
        public void CountTest2()
        {
            // arrange
            var words = new[] { "this", "is", "a", "statement", "and", "so", "is", "this" };
            
            // act
            var dictionary = _counter.Count(words);

            // assert           
            CollectionAssert.AreEquivalent(new [] {"this", "is", "a", "statement", "and", "so"}, dictionary.Keys);
            Assert.AreEqual(2, dictionary["this"]);
            Assert.AreEqual(2, dictionary["is"]);
            Assert.AreEqual(1, dictionary["a"]);
            Assert.AreEqual(1, dictionary["statement"]);
            Assert.AreEqual(1, dictionary["and"]);
            Assert.AreEqual(1, dictionary["so"]);
        }

        [Test]
        public void CountTest3()
        {
            // act
            var dictionary = _counter.Count(null);

            // assert  
            Assert.IsNull(dictionary);

        }
    }
}
