namespace PragmaticSegmenterNet
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal static class Cleaner
    {
        private static readonly Regex AnyNonPeriodMatchRegex = new Regex(@"(?:[^\.])*");
        private static readonly Regex NewlineInMiddleOfSentenceRegex = new Regex(@"(?<=\s)\n(?=([a-z]|\())");
        private static readonly Rule NewlineInMiddleOfWordRule = new Rule(@"\n(?=[a-zA-Z]{1,2}\n)", string.Empty);
        private static readonly Rule DoubleNewlineRule = new Rule(@"\n ?\n", "\r");
        private static readonly Rule NewlineFollowedByPeriodRule = new Rule(@"\n(?=\.(\s|\n))", string.Empty);
        private static readonly Rule ReplaceNewlineWithCarriageReturnRule = new Rule(@"\n", "\r");
        private static readonly Rule NewlineFollowedByBulletRule = new Rule(@"\n(?=•)", "\r");

        // For PDFs
        private static readonly Rule NewlineInMiddleOfSentenceRule = new Rule(@"(?<=[^\n]\s)\n(?=\S)", string.Empty);
        private static readonly Rule NewlineInMiddleOfSentenceNoSpacesRule = new Rule(@"\n(?=[a-z])", " ");

        // For HTMLs
        private static readonly Rule HtmlTagRule = new Rule(@"<\/?\w+((\s+\w+(\s*=\s*(?:"".*?""|'.*?'|[\^'"">\s]+))?)+\s*|\s*)\/?>", string.Empty);
        private static readonly Rule EscapedHtmlTagRule = new Rule(@"&lt;\/?[^gt;]*gt;", string.Empty);

        private static readonly Rule EscapedNewlineRule = new Rule(@"\\ ?n", "\n");
        private static readonly Rule EscapedCarriageReturnRule = new Rule(@"\\ ?r", "\r");

        private static readonly Regex QuestionMarkInSquareBracketsRegex = new Regex(@"(?<=\[[^\]]*)\?(?=[^\[]*\])");

        private static readonly Rule InlineFormattingRule = new Rule(@"\{b\^&gt;\d*&lt;b\^\}|\{b\^>\d*<b\^\}", string.Empty);

        private static readonly Rule QuotationsFirstRule = new Rule("''", "\"");
        private static readonly Rule QuotationsSecondRule = new Rule("``", "\"");


        private static readonly Rule TableOfContentsRule = new Rule(@"\.{5,}\s*\d+-*\d*", "\r");
        private static readonly Rule ConsecutivePeriodsRule = new Rule(@"\.{5,}", " ");
        private static readonly Rule ConsecutiveForwardSlashRule = new Rule(@"\/{3}", string.Empty);

        private static readonly IReadOnlyList<string> UrlAndEmailKeywords = new[]
        {
            "@", "http", ".com", "net", "www", "//"
        };

        private static readonly char[] Splitters = { ' ' };
        
        private static readonly Regex NoSpaceBetweenSentencesDigitRegex = new Regex(@"(?<=\d)\.(?=[A-Z])");
        private static readonly Rule NoSpaceBetweenSentencesDigitRule = new Rule(NoSpaceBetweenSentencesDigitRegex, ". ");

        public static string Clean(string text, ILanguage language, DocumentType documentType = DocumentType.Any)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            var result = RemoveAllNewlines(text);
            result = DoubleNewlineRule.Apply(result);
            result = ReplaceNewlines(result, documentType);
            result = EscapedNewlineRule.Apply(result);
            result = EscapedCarriageReturnRule.Apply(result);
            result = HtmlTagRule.Apply(result);
            result = EscapedHtmlTagRule.Apply(result);

            result = ReplaceQuestionMarkInSquareBrackets(result);
            result = InlineFormattingRule.Apply(result);

            result = QuotationsFirstRule.Apply(result);
            result = QuotationsSecondRule.Apply(result);

            result = TableOfContentsRule.Apply(result);
            result = ConsecutivePeriodsRule.Apply(result);
            result = ConsecutiveForwardSlashRule.Apply(result);

            result = CheckForNoSpaceInBetweenSentences(result, language);

            result = ConsecutivePeriodsRule.Apply(result);
            result = ConsecutiveForwardSlashRule.Apply(result);

            result = language.CleanerBehaviour.OnClean(result);

            return result;
        }

        private static string RemoveAllNewlines(string text)
        {
            var result = AnyNonPeriodMatchRegex.Replace(text, x => NewlineInMiddleOfSentenceRegex.Replace(x.Value, string.Empty));

            result = NewlineInMiddleOfWordRule.Apply(result);

            return result;
        }

        private static string ReplaceNewlines(string text, DocumentType type)
        {
            if (type == DocumentType.Pdf)
            {
                var result = NewlineFollowedByBulletRule.Apply(text);
                result = NewlineInMiddleOfSentenceRule.Apply(result);
                result = NewlineInMiddleOfSentenceNoSpacesRule.Apply(result);
                return result;
            }
            else
            {
                var result = NewlineFollowedByPeriodRule.Apply(text);
                result = ReplaceNewlineWithCarriageReturnRule.Apply(result);
                return result;
            }
        }

        private static string ReplaceQuestionMarkInSquareBrackets(string text)
        {
            var result = QuestionMarkInSquareBracketsRegex.Replace(text, "&ᓷ&");
            return result;
        }

        private static string CheckForNoSpaceInBetweenSentences(string text, ILanguage language)
        {
            var words = text.Split(Splitters);

            var result = text;

            foreach (var word in words)
            {
                result = SearchForConnectedSentences(word, result, language.CleanerBehaviour.NoSpaceBetweenSentencesRegex, language.CleanerBehaviour.NoSpaceBetweenSentencesRule, language);
                result = SearchForConnectedSentences(word, result, NoSpaceBetweenSentencesDigitRegex, NoSpaceBetweenSentencesDigitRule, language);
            }

            return result;
        }

        private static string SearchForConnectedSentences(string word, string txt, Regex regex, Rule rule, ILanguage language)
        {
            if (!regex.IsMatch(word))
            {
                return txt;
            }

            for (var i = 0; i < UrlAndEmailKeywords.Count; i++)
            {
                var webTerm = UrlAndEmailKeywords[i];

                if (word.Contains(webTerm))
                {
                    return txt;
                }
            }

            for (var i = 0; i < language.CleanedAbbreviations.Count; i++)
            {
                var abbr = language.CleanedAbbreviations[i];
                
                if (word.IndexOf(abbr, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return txt;
                }
            }

            var newWord = rule.Apply(word);

            var result = Regex.Replace(txt, $"{Regex.Escape(word)}", newWord);

            return result;
        }
    }
}
