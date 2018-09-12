namespace PragmaticSegmenterNet.Languages
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class BulgarianLanguage : LanguageBase
    {
        private static readonly IReadOnlyList<string> AbbreviationStore = new[]
        {
            "p.s", "акад", "ал", "б.р",
            "б.ред", "бел.а", "бел.пр", "бр", "бул", "в", "вж", "вкл", "вм", "вр",
            "г", "ген", "гр", "дж", "дм", "доц", "др", "ем", "заб", "зам", "инж", "к.с", "кв", "кв.м", "кг", "км",
            "кор", "куб", "куб.м", "л", "лв", "м", "м.г", "мин", "млн", "млрд", "мм", "н.с", "напр", "пл", "полк",
            "проф", "р", "рис", "с", "св", "сек", "см", "сп", "срв", "ст", "стр", "т", "т.г", "т.е", "т.н", "т.нар",
            "табл", "тел", "у", "ул", "фиг", "ха", "хил", "ч", "чл", "щ.д"
        };

        public override IReadOnlyList<string> Abbreviations { get; } = AbbreviationStore;

        public override IReadOnlyList<string> NumberAbbreviations { get; } = Empty;

        public override IReadOnlyList<string> PrepositiveAbbreviations { get; } = Empty;

        public override IReadOnlyList<string> SentenceStarters { get; } = Empty;

        public override IAbbreviationReplacer AbbreviationReplacer { get; }

        public BulgarianLanguage()
        {
            AbbreviationReplacer = new BulgarianAbbreviationReplacer(this);
        }

        private class BulgarianAbbreviationReplacer : AbbreviationReplacerBase
        {
            public BulgarianAbbreviationReplacer(ILanguage language) : base(language)
            {
            }

            protected override string ReplacePeriodInAbbreviation(string text, string abbreviation)
            {
                var trimmed = abbreviation.Trim();

                var result = Regex.Replace(text, $"(?<=\\s{trimmed})\\.|(?<=^{trimmed})\\.", "∯");

                return result;
            }
        }
    }
}