namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class UrduLanguageTests
    {
        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment("کیا حال ہے؟ ميرا نام ___ ەے۔ میں حالا تاوان دےدوں؟", Language.Urdu);
            Assert.Equal(new[] { "کیا حال ہے؟", "ميرا نام ___ ەے۔", "میں حالا تاوان دےدوں؟" }, result);
        }
    }
}