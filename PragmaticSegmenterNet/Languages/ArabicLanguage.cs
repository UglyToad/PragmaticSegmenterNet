namespace PragmaticSegmenterNet.Languages
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class ArabicLanguage : LanguageBase
    {
        public override IReadOnlyList<string> Punctuations { get; } = new[]
        {
            "?", "!", ":", ".", "؟", "،"
        };

        public override Regex SentenceBoundaryRegex { get; } = new Regex(@".*?[:\.!\?؟،]|.*?\z|.*?$");

        public override IReadOnlyList<string> Abbreviations { get; } = new[]
        {
            "ا", "ا. د", "ا.د", "ا.ش.ا", "ا.ش.ا", "إلخ", "ت.ب", "ت.ب", "ج.ب", "جم", "ج.ب", "ج.م.ع", "ج.م.ع", "س.ت", "س.ت", "سم", "ص.ب.", "ص.ب", "كج.", "كلم.", "م", "م.ب", "م.ب", "ه", "د‪"
        };

        public override IReadOnlyList<string> PrepositiveAbbreviations { get; } = Empty;

        public override IReadOnlyList<string> NumberAbbreviations { get; } = Empty;

        public override Rule ReplaceColonBetweenNumbersRule { get; } = new Rule(@"(?<=\d):(?=\d)", "♭");

        public override Rule ReplaceNonSentenceBoundaryCommaRule { get; } = new Rule(@"،(?=\s\S+،)", "♬");

        public override IReadOnlyList<string> SentenceStarters { get; } = Empty;

        public override IAbbreviationReplacer AbbreviationReplacer { get; }

        public ArabicLanguage()
        {
            AbbreviationReplacer = new ArabicAbbreviationReplacer(this);
        }

        private class ArabicAbbreviationReplacer : AbbreviationReplacerBase
        {
            public ArabicAbbreviationReplacer(ILanguage language) : base(language)
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
