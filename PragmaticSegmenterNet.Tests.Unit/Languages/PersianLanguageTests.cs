namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class PersianLanguageTests
    {
        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment("خوشبختم، آقای رضا. شما کجایی هستید؟ من از تهران هستم.", Language.Persian);
            Assert.Equal(new[] { "خوشبختم، آقای رضا.", "شما کجایی هستید؟", "من از تهران هستم." }, result);
        }
    }
}