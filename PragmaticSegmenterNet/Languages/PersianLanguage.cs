namespace PragmaticSegmenterNet.Languages
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class PersianLanguage : LanguageBase
    {
        public override Regex SentenceBoundaryRegex { get; } = new Regex(@".*?[:\.!\?؟]|.*?\z|.*?$");

        public override IReadOnlyList<string> Punctuations { get; } = new[] {"?", "!", ":", ".", "؟"};

        public override Rule ReplaceColonBetweenNumbersRule { get; } = new Rule(@"(?<=\d):(?=\d)", "♭");

        public override Rule ReplaceNonSentenceBoundaryCommaRule { get; } = new Rule(@"،(?=\s\S+،)", "♬");

        public override IReadOnlyList<string> SentenceStarters { get; } = Empty;

        public override IAbbreviationReplacer AbbreviationReplacer { get; }

        public PersianLanguage()
        {
            AbbreviationReplacer = new PersianAbbreviationReplacer(this);
        }

        private class PersianAbbreviationReplacer : AbbreviationReplacerBase 
        {
            public PersianAbbreviationReplacer(ILanguage language) : base(language)
            {
            }

            protected override string ScanForReplacements(string text, int index, Match match, MatchCollection characterArray)
            {
                var result = Regex.Replace(text, $"(?<={match.Value})\\.", "∯");

                return result;
            }
        }
    }
}