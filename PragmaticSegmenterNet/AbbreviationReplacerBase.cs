namespace PragmaticSegmenterNet
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class AbbreviationReplacerBase : IAbbreviationReplacer
    {
        protected readonly ILanguage Language;

        public AbbreviationReplacerBase(ILanguage language)
        {
            Language = language;
        }

        public virtual string Replace(string text)
        {
            text = Language.PossessiveAbbreviationRule.Apply(text);
            text = Language.KommanditgesellschaftRule.Apply(text);
            text = Language.SingleLetterAbbreviationRules.Apply(text);

            text = SearchForAbbreviations(text);
            text = ReplaceMultiPeriodAbbreviations(text);
            text = Language.AmPmRules.Apply(text);
            text = ReplaceAbbreviationAsSentenceBoundary(text);

            return text;
        }

        protected virtual string SearchForAbbreviations(string text)
        {
            var original = text;

            for (var i = 0; i < Language.Abbreviations.Count; i++)
            {
                var abbreviation = Language.Abbreviations[i];

                if (original.IndexOf(abbreviation, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    continue;
                }

                var escapedAbbreviation = Regex.Escape(abbreviation);

                var matches = Regex.Matches(original, @"(?:^|\s|\r|\n)" + escapedAbbreviation, RegexOptions.IgnoreCase);

                if (matches.Count == 0)
                {
                    continue;
                }

                var characterArray = Regex.Matches(original, $"(?<={escapedAbbreviation} ).{{1}}");

                for (var j = 0; j < matches.Count; j++)
                {
                    var match = matches[j];

                    text = ScanForReplacements(text, j, match, characterArray);
                }
            }

            return text;
        }

        protected virtual string ScanForReplacements(string text, int index, Match match, MatchCollection characterArray)
        {
            var character = index >= characterArray.Count ? default(Match) : characterArray[index];

            var prepositiveAbbreviations = Language.PrepositiveAbbreviations;
            var numberAbbreviations = Language.NumberAbbreviations;

            var matchValue = match.Value.Trim();
            var isPrepositiveAbbreviation = IsInList(matchValue, prepositiveAbbreviations);

            var upper = character != null && HasRubyUpper(character.Value);

            if (!upper || isPrepositiveAbbreviation)
            {
                if (isPrepositiveAbbreviation)
                {
                    return ReplacePrepositiveAbbreviation(text, matchValue);
                }

                if (IsInList(matchValue, numberAbbreviations))
                {
                    return ReplacePreNumberAbbreviation(text, matchValue);
                }

                return ReplacePeriodInAbbreviation(text, matchValue);
            }

            return text;
        }

        protected virtual string ReplacePrepositiveAbbreviation(string text, string abbreviation)
        {
            text = Regex.Replace(text, $"(?<=\\s{abbreviation})\\.(?=\\s)|(?<=^{abbreviation})\\.(?=\\s)", Constants.ReplacedSymbol);
            text = Regex.Replace(text, $"(?<=\\s{abbreviation})\\.(?=:\\d+)|(?<=^{abbreviation})\\.(?=:\\d+)", Constants.ReplacedSymbol);
            return text;
        }

        protected virtual string ReplacePreNumberAbbreviation(string text, string abbreviation)
        {
            text = Regex.Replace(text,
                $"(?<=\\s{abbreviation})\\.(?=\\s\\d)|(?<=^{abbreviation})\\.(?=\\s\\d)",
                Constants.ReplacedSymbol);
            text = Regex.Replace(text,
                $"(?<=\\s{abbreviation})\\.(?=\\s+\\()|(?<=^{abbreviation})\\.(?=\\s+\\()",
                Constants.ReplacedSymbol);

            return text;
        }

        protected virtual string ReplacePeriodInAbbreviation(string text, string abbreviation)
        {
            text = Regex.Replace(text,
                $"(?<=\\s{abbreviation})\\.(?=((\\.|\\:|-|\\?)|(\\s([a-z]|I\\s|I'm|I'll|\\d|\\(|\\[))))|(?<=^{abbreviation})\\.(?=((\\.|\\:|\\?)|(\\s([a-z]|I\\s|I'm|I'll|\\d|\\[))))",
                Constants.ReplacedSymbol);

            text = Regex.Replace(text,
                $"(?<=\\s{abbreviation})\\.(?=,)|(?<=^{abbreviation})\\.(?=,)",
                Constants.ReplacedSymbol);

            return text;
        }

        protected virtual string ReplaceMultiPeriodAbbreviations(string text)
        {
            var matches = Language.MultiPeriodAbbreviationRegex.Matches(text);

            foreach (Match match in matches)
            {
                var pattern = Regex.Escape(match.Value);

                var replacement = match.Value.Replace('.', '∯');

                text = Regex.Replace(text, pattern, replacement);
            }

            return text;
        }

        protected virtual string ReplaceAbbreviationAsSentenceBoundary(string text)
        {
            foreach (var word in Language.SentenceStarters)
            {
                var escaped = Regex.Escape(word);

                text = Regex.Replace(text,
                    $"(U∯S|U\\.S|U∯K|E∯U|E\\.U|U∯S∯A|U\\.S\\.A|I|i.v|I.V)∯(?=\\s{escaped}\\s)",
                    "$1.");
            }

            return text;
        }

        private static bool IsInList(string text, IReadOnlyList<string> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var val = list[i];

                if (string.Equals(val, text, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HasRubyUpper(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsUpper(s[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
