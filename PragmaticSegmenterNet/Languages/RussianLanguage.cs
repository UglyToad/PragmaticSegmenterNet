namespace PragmaticSegmenterNet.Languages
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class RussianLanguage : LanguageBase
    {
        private static readonly IReadOnlyList<string> AbbreviationStore = new[]
        {
            "y", "y.e", "а", "авт", "адм.-терр", "акад", "в", "вв", "вкз", "вост.-европ", "г", "гг", "гос", "гр", "д", "деп", "дисс", "дол", "долл", "ежедн", "ж", "жен", "з", "зап", "зап.-европ", "заруб", "и", "ин", "иностр", "инст", "к", "канд",
            "кв", "кг", "куб", "л", "л.h", "л.н", "м", "мин", "моск", "муж", "н", "нед", "о", "п", "пгт", "пер", "пп", "пр", "просп", "проф", "р", "руб", "с", "сек", "см", "спб", "стр", "т", "тел", "тов", "тт", "тыс", "у", "у.е", "ул", "ф", "ч"
        };

        public override IReadOnlyList<string> Abbreviations { get; } = AbbreviationStore;

        public override IReadOnlyList<string> PrepositiveAbbreviations { get; } = Empty;

        public override IReadOnlyList<string> NumberAbbreviations { get; } = Empty;

        public override IReadOnlyList<string> SentenceStarters { get; } = Empty;

        public override IAbbreviationReplacer AbbreviationReplacer { get; }

        public RussianLanguage()
        {
            AbbreviationReplacer = new RussianAbbreviationReplacer(this);
        }

        private class RussianAbbreviationReplacer : AbbreviationReplacerBase
        {
            public RussianAbbreviationReplacer(ILanguage language) : base(language)
            {
            }

            protected override string ReplacePeriodInAbbreviation(string text, string abbreviation)
            {
                var trimmed = abbreviation.Trim();
                var result = Regex.Replace(text, $"(?<=\\s{trimmed})\\.", "∯");
                result = Regex.Replace(result, $"(?<=^{trimmed})\\.", "∯");

                return result;
            }
        }
    }
}