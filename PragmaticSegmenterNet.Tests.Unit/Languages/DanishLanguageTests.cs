namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class DanishLanguageTests
    {
        [Fact]
        public void SimplePeriodToEndSentence001()
        {
            var result = Segmenter.Segment("Hej Verden. Mit navn er Jonas.", Language.Danish);
            Assert.Equal(new[] { "Hej Verden.", "Mit navn er Jonas." }, result);
        }

        [Fact]
        public void QuestionMarkToEndSentence002()
        {
            var result = Segmenter.Segment("Hvad er dit navn? Mit nav er Jonas.", Language.Danish);
            Assert.Equal(new[] { "Hvad er dit navn?", "Mit nav er Jonas." }, result);
        }

        [Fact]
        public void TwoLetterLowerCaseAbbreviationsAtTheEndOfASentence003()
        {
            var result = Segmenter.Segment("Lad os spørge Jane og co. De burde vide det.", Language.Danish);
            Assert.Equal(new[] { "Lad os spørge Jane og co.", "De burde vide det." }, result);
        }

        [Fact]
        public void TwoLetterUpperCaseAbbreviationsAtTheEndOfASentence004()
        {
            var result = Segmenter.Segment("De lukkede aftalen med Pitt, Briggs & Co. Det lukkede i går.", Language.Danish);
            Assert.Equal(new[] { "De lukkede aftalen med Pitt, Briggs & Co.", "Det lukkede i går." }, result);
        }

        [Fact]
        public void TwoLetterPrepositiveAbbreviations005()
        {
            var result = Segmenter.Segment("De holdt Skt. Hans i byen.", Language.Danish);
            Assert.Equal(new[] { "De holdt Skt. Hans i byen." }, result);
        }

        [Fact]
        public void TwoLetterPrepositivePostpositiveAbbreviations006()
        {
            var result = Segmenter.Segment("St. Michael's Kirke er på 5. gade nær ved lyset.", Language.Danish);
            Assert.Equal(new[] { "St. Michael's Kirke er på 5. gade nær ved lyset." }, result);
        }

        [Fact]
        public void MultiperiodAbbreviationsAtTheEndOfASentence007()
        {
            var result = Segmenter.Segment("Jeg bor i E.U. Hvad med dig?", Language.Danish);
            Assert.Equal(new[] { "Jeg bor i E.U.", "Hvad med dig?" }, result);
        }

        [Fact]
        public void UnitedStatesAsSentenceBoundary008()
        {
            var result = Segmenter.Segment("I live in the U.S. Hvad med dig?", Language.Danish);
            Assert.Equal(new[] { "I live in the U.S.", "Hvad med dig?" }, result);
        }
    }
}