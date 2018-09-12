namespace PragmaticSegmenterNet
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal static class PunctuationReplacer
    {
        private static readonly IReadOnlyList<Rule> EscapeRegexReservedCharacterRules = new[]
        {
            new Rule(@"\(", @"\\("),
            new Rule(@"\)", @"\\)"),
            new Rule(@"\[", @"\\["),
            new Rule(@"\]", @"\\]"),
            new Rule(@"\-", @"\\-")
        };

        private static readonly IReadOnlyList<Rule> SubEscapedRegexReservedCharacterRules = new Rule[]
        {
            new Rule(@"\\\\\(", @"("),
            new Rule(@"\\\\\)", @")"),
            new Rule(@"\\\\\[", @"["),
            new Rule(@"\\\\\]", @"]"),
            new Rule(@"\\\\\-", @"-")
        };

        public static string Replace(string text, MatchCollection matches, PunctuationReplacerType type = PunctuationReplacerType.Normal) => Replace(text, new MatchSet(matches), type);
        public static string Replace(string text, MatchSet matchSet, PunctuationReplacerType type = PunctuationReplacerType.Normal)
        {
            if (matchSet == null || matchSet.Count == 0)
            {
                return text;
            }
            
            text = EscapeRegexReservedCharacterRules.Apply(text);

            foreach (var match in matchSet.Matches)
            {
                var val = match.Value;
                val = EscapeRegexReservedCharacterRules.Apply(val);

                var sub = SubstituteCharacters(val, ref text, ".", "∯");
                sub = SubstituteCharacters(sub, ref text, "。", "&ᓰ&");
                sub = SubstituteCharacters(sub, ref text, "．", "&ᓱ&");
                sub = SubstituteCharacters(sub, ref text, "！", "&ᓳ&");
                sub = SubstituteCharacters(sub, ref text, "!", "&ᓴ&");
                sub = SubstituteCharacters(sub, ref text, "?", "&ᓷ&");
                sub = SubstituteCharacters(sub, ref text, "？", "&ᓸ&");

                if (type != PunctuationReplacerType.Single)
                {
                    sub = SubstituteCharacters(sub, ref text, "'", "&⎋&");
                }

                // TODO: line 50 punctuation_replacer.rb, sub a for b then regex into text.
            }

            text = SubEscapedRegexReservedCharacterRules.Apply(text);

            return text;
        }

        private static string SubstituteCharacters(string input, ref string text, string target, string replacement)
        {
            var substitute = input.Replace(target, replacement);
            text = Regex.Replace(text, Regex.Escape(input), substitute);
            return substitute;
        }
    }
}