namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class DutchLanguageTests
    {
        [Fact]
        public void SentenceStartingWithNumber001()
        {
            var result = Segmenter.Segment("Hij schoot op de JP8-brandstof toen de Surface-to-Air (sam)-missiles op hem af kwamen. 81 procent van de schoten was raak.", Language.Dutch);
            Assert.Equal(new[] {"Hij schoot op de JP8-brandstof toen de Surface-to-Air (sam)-missiles op hem af kwamen.", "81 procent van de schoten was raak."}, result);
        }

        [Fact]
        public void SentenceStartingWithEllipsis002()
        {
            var result = Segmenter.Segment("81 procent van de schoten was raak. ...en toen barste de hel los.", Language.Dutch);
            Assert.Equal(new[] { "81 procent van de schoten was raak.", "...en toen barste de hel los." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment("Afkorting aanw. vnw.", Language.Dutch);
            Assert.Equal(new[] { "Afkorting aanw. vnw." }, result);
        }
    }
}
