namespace PragmaticSegmenterNet.Languages
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class JapaneseLanguage : LanguageBase
    {
        private static readonly IBetweenPunctuationReplacer BetweenPunctuationReplacerInstance = new JapaneseBetweenPunctuationReplacer();
        private static readonly ICleanerBehaviour CleanerBehaviourInstance = new JapaneseCleanerBehaviour();
        private static readonly Rule NewLineInMiddleOfWordRule = new Rule(@"(?<=の)[\n\r](?=\S)", string.Empty);

        public override IReadOnlyList<string> SentenceStarters { get; } = Empty;

        public override IBetweenPunctuationReplacer BetweenPunctuationReplacer { get; } = BetweenPunctuationReplacerInstance;

        public override ICleanerBehaviour CleanerBehaviour { get; } = CleanerBehaviourInstance; 

        private class JapaneseBetweenPunctuationReplacer : BetweenPunctuationReplacer
        {
            private static readonly Regex BetweenQuoteJapaneseRegex = new Regex(@"\u300c(?>[^\u300c\u300d\\]+|\\{2}|\\.)*\u300d");
            private static readonly Regex BetweenParenthesesJapaneseRegex = new Regex(@"\uff08(?>[^\uff08\uff09\\]+|\\{2}|\\.)*\uff09");

            protected override string SubstitutePunctuationBetweenQuotesAndParens(string text)
            {
                var result = base.SubstitutePunctuationBetweenQuotesAndParens(text);
                result = SubstituteUsingRegex(BetweenParenthesesJapaneseRegex, result);
                result = SubstituteUsingRegex(BetweenQuoteJapaneseRegex, result);

                return result;
            }
        }

        private class JapaneseCleanerBehaviour : CleanerBehaviourBase
        {
            public override string OnClean(string text)
            {
                var result = base.OnClean(text);
                result = NewLineInMiddleOfWordRule.Apply(result);

                return result;
            }
        }
    }
}
