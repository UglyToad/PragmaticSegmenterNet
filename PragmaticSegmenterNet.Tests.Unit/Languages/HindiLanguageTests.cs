namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class HindiLanguageTests
    {
        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment("सच्चाई यह है कि इसे कोई नहीं जानता। हो सकता है यह फ़्रेन्को के खिलाफ़ कोई विद्रोह रहा हो, या फिर बेकाबू हो गया कोई आनंदोत्सव।", Language.Hindi);
            Assert.Equal(new[] { "सच्चाई यह है कि इसे कोई नहीं जानता।", "हो सकता है यह फ़्रेन्को के खिलाफ़ कोई विद्रोह रहा हो, या फिर बेकाबू हो गया कोई आनंदोत्सव।" }, result);
        }
    }
}