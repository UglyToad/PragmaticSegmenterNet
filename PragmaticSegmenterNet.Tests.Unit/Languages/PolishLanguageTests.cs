namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class PolishLanguageTests
    {
        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment("To słowo bałt. jestskrótem.", Language.Polish);
            Assert.Equal(new[] { "To słowo bałt. jestskrótem." }, result);
        }
    }
}