namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class GreekLanguageTests
    {
        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment("Με συγχωρείτε· πού είναι οι τουαλέτες; Τις Κυριακές δε δούλευε κανένας. το κόστος του σπιτιού ήταν £260.950,00.", Language.Greek);
            Assert.Equal(new[] { "Με συγχωρείτε· πού είναι οι τουαλέτες;", "Τις Κυριακές δε δούλευε κανένας.", "το κόστος του σπιτιού ήταν £260.950,00." }, result);
        }
    }
}
