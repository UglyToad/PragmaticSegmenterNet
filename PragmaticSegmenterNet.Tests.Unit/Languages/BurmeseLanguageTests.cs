namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class BurmeseLanguageTests
    {
        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment("ခင္ဗ်ားနာမည္ဘယ္လိုေခၚလဲ။၇ွင္ေနေကာင္းလား။", Language.Burmese);
            Assert.Equal(new[] { "ခင္ဗ်ားနာမည္ဘယ္လိုေခၚလဲ။", "၇ွင္ေနေကာင္းလား။" }, result);
        }
    }
}
