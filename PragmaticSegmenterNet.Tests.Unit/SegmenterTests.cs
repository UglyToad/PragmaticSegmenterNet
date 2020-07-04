namespace PragmaticSegmenterNet.Tests.Unit
{
    using Xunit;

    public class SegmenterTests
    {
        [Fact]
        public void HandlesNull()
        {
            var result = Segmenter.Segment(null);

            Assert.Empty(result);
        }

        [Fact]
        public void HandlesEmptyString()
        {
            var result = Segmenter.Segment(string.Empty);

            Assert.Empty(result);
        }

        [Fact]
        public void HandlesNewLine()
        {
            var result = Segmenter.Segment("\n");

            Assert.Empty(result);
        }

        [Fact]
        public void HandlesWhitespace()
        {
            var result = Segmenter.Segment("        ");

            Assert.Empty(result);
        }

        [Fact]
        public void HandlesSimplestCase()
        {
            var result = Segmenter.Segment("Hello world. Hello.");

            Assert.Equal(new []
            {
                "Hello world.",
                "Hello."
            }, result);
        }

        [Fact]
        public void HandlesRegexContainingText()
        {
            var result = Segmenter.Segment("('$0 xyz, $1 abc, $0 def').");

            Assert.Equal(1, result.Count);

            Assert.Equal("('$0 xyz, $1 abc, $0 def').", result[0]);
        }

        [Fact]
        public void HandlesNonBreakingSpaceText()
        {
            var result = Segmenter.Segment("Trututu\u00A01. trututu\u00A02. trututu");

            Assert.Equal(3, result.Count);
            Assert.Equal("Trututu", result[0]);
            Assert.Equal("1. trututu", result[1]);
            Assert.Equal("2. trututu", result[2]);
        }
    }
}
