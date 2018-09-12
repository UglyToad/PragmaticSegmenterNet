namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class AmharicLanguageTests
    {
        [Fact]
        public void SentenceEndingPunctuation001()
        {
            var result = Segmenter.Segment("እንደምን አለህ፧መልካም ቀን ይሁንልህ።እባክሽ ያልሽዉን ድገሚልኝ።", Language.Amharic);
            Assert.Equal(new[] {"እንደምን አለህ፧", "መልካም ቀን ይሁንልህ።", "እባክሽ ያልሽዉን ድገሚልኝ።"}, result);
        }
    }
}
