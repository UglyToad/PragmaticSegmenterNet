namespace PragmaticSegmenterNet.Languages
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class ArmenianLanguage : LanguageBase
    {
        public override Regex SentenceBoundaryRegex { get; } = new Regex(@".*?[։՜:]|.*?$");
        public override IReadOnlyList<string> Punctuations { get; } = new[] { "։", "՜", ":" };
        public override IReadOnlyList<string> SentenceStarters { get; } = Empty;
    }
}
