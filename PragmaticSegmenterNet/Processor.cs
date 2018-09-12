namespace PragmaticSegmenterNet
{
    using System.Collections.Generic;

    internal static class Processor
    {
        public static IReadOnlyList<string> Process(string text, ILanguage language)
        {
            text = ListItemReplacer.AddLineBreak(text);
            text = language.AbbreviationReplacer.Replace(text);
            text = language.NumberRules.Apply(text);
            text = ReplaceContinuousPunctuation(text, language);
            text = language.WithMultiplePeriodsAndEmailRule.Apply(text);
            text = language.GeoLocationRule.Apply(text);
            text = language.FileFormatRule.Apply(text);

            var segments = InternalSegmenter.Segment(text, language);

            return segments;
        }

        private static string ReplaceContinuousPunctuation(string input, ILanguage language)
        {
            input = language.ContinuousPunctuationRegex.Replace(input, x =>
            {
                var val = x.Value;
                return val.Replace("!", "&ᓴ&")
                    .Replace("?", "&ᓷ&");
            });

            return input;
        }
    }
}