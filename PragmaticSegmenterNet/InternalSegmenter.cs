namespace PragmaticSegmenterNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal static class InternalSegmenter
    {
        private static readonly char[] NewLineSplit = { '\r' };

        private static readonly Regex BetweenQuotesFirstRegex = new Regex(@"\s(?=\()");
        private static readonly Regex BetweenQuotesSecondRegex = new Regex(@"(?<=\))\s");
        private static readonly Regex ShortSegmentRegex = new Regex(@"\A[a-zA-Z]*\Z");
        private static readonly Regex ConsecutiveUnderscoreRegex = new Regex(@"_{3,}");

        public static IReadOnlyList<string> Segment(string text, ILanguage language)
        {
            var splitByReference = ReferenceSeparator.SeparateReferences(text);
            var newLined = CheckForParenthesesBetweenQuotes(splitByReference, language);
            var parts = newLined.Split(NewLineSplit)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList();

            for (var i = 0; i < parts.Count; i++)
            {
                var part = parts[i];

                part = language.SingleNewLineRule.Apply(part);

                part = language.EllipsisRules.Apply(part);

                parts[i] = part;
            }

            for (var i = 0; i < parts.Count; i++)
            {
                var split = CheckForPunctuation(parts[i], language);

                if (split.Count == 0)
                {
                    continue;
                }

                if (split.Count == 1)
                {
                    parts[i] = language.SubSymbolsRules.Apply(split[0]);
                }
                else
                {
                    parts[i] = language.SubSymbolsRules.Apply(split[0]);
                    for (var j = 1; j < split.Count; j++)
                    {
                        var part = language.SubSymbolsRules.Apply(split[j]);
                        parts.Insert(i + j, part);
                    }

                    i += split.Count - 1;
                }
            }

            for (var i = 0; i < parts.Count; i++)
            {
                if (parts[i].Length <= 2)
                {
                    continue;
                }

                var newParts = PostProcessSegment(parts[i], language);

                if (newParts.Length == 0)
                {
                    parts.RemoveAt(i);
                    i--;
                }
                else
                {
                    parts[i] = language.SubSingleQuoteRule.Apply(newParts[0]);

                    if (newParts.Length > 1)
                    {
                        for (var j = 1; j < newParts.Length; j++)
                        {
                            var insert = language.SubSingleQuoteRule.Apply(newParts[j]);
                            parts.Insert(i + j, insert);
                        }

                        i += newParts.Length - 1;
                    }
                }
            }

            for (var i = 0; i < parts.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(parts[i]))
                {
                    parts.RemoveAt(i);
                    i--;
                }
                else
                {
                    parts[i] = RevertRegexGroupReplacement(parts[i]);
                }
            }

            return parts;
        }

        private static string RevertRegexGroupReplacement(string text)
        {
            return text.Replace("&☃", "$");
        }

        private static string CheckForParenthesesBetweenQuotes(string text, ILanguage language)
        {
            if (!language.ParenthesesBetweenDoubleQuotesRegex.IsMatch(text))
            {
                return text;
            }

            text = language.ParenthesesBetweenDoubleQuotesRegex.Replace(text, match =>
            {
                var withNewline = BetweenQuotesFirstRegex.Replace(match.Value, "\r");
                var result = BetweenQuotesSecondRegex.Replace(withNewline, "\r");

                return result;
            });

            return text;
        }

        private static IReadOnlyList<string> CheckForPunctuation(string text, ILanguage language)
        {
            var containsPunctuation = false;
            var endsWithPunctuation = false;

            for (var i = 0; i < language.Punctuations.Count; i++)
            {
                var index = text.IndexOf(language.Punctuations[i], StringComparison.OrdinalIgnoreCase);
                if (index >= 0)
                {
                    containsPunctuation = true;

                    if (!endsWithPunctuation)
                    {
                        endsWithPunctuation = index == text.Length - 1;
                    }
                }
            }

            if (!containsPunctuation)
            {
                return new[] { text };
            }

            if (!endsWithPunctuation)
            {
                text += "ȸ";
            }

            text = ExclamationWords.Apply(text);
            text = language.BetweenPunctuationReplacer.Replace(text);
            text = language.DoublePunctuationRules.Apply(text);
            text = language.QuestionMarkInQuotationRule.Apply(text);
            text = language.ExclamationMarkRules.Apply(text);

            text = ListItemReplacer.ReplaceParentheses(text);

            var result = SplitUsingSentenceBoundaryPunctuation(text, language);

            return result;
        }

        private static IReadOnlyList<string> SplitUsingSentenceBoundaryPunctuation(string text, ILanguage language)
        {
            text = language.ReplaceColonBetweenNumbersRule.Apply(text);
            text = language.ReplaceNonSentenceBoundaryCommaRule.Apply(text);

            var matches = language.SentenceBoundaryRegex.Matches(text);

            var result = new string[matches.Count];

            for (var i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].Value;
            }

            return result;
        }

        private static string[] PostProcessSegment(string segment, ILanguage language)
        {
            if (segment.Length < 2 && ShortSegmentRegex.IsMatch(segment))
            {
                return new[] { segment };
            }

            if (segment.Length < 2 || HasConsecutiveUnderscore(segment))
            {
                // TODO: could be wrong...
                return new string[0];
            }

            segment = language.ReinsertEllipsisRules.Apply(segment);
            segment = language.ExtraWhiteSpaceRule.Apply(segment);

            if (language.QuotationAtEndOfSentenceRegex.IsMatch(segment))
            {
                return language.SplitSpaceQuotationAtEndOfSentenceRegex.Split(segment);
            }

            segment = segment.Replace("\n", string.Empty).Trim();

            return new[] { segment };
        }

        private static bool HasConsecutiveUnderscore(string text)
        {
            var replaced = ConsecutiveUnderscoreRegex.Replace(text, string.Empty);

            return replaced.Length == 0;
        }
    }
}
