namespace PragmaticSegmenterNet
{
    using System.Collections.Generic;

    internal static class RuleExtensions
    {
        public static string Apply(this IReadOnlyList<Rule> rules, string text)
        {
            if (rules == null)
            {
                return text;
            }

            for (var i = 0; i < rules.Count; i++)
            {
                text = rules[i].Apply(text);
            }

            return text;
        }
    }
}