namespace PragmaticSegmenterNet.Languages.Common
{
    using System.Collections.Generic;

    internal static class SingleLetterAbbreviationRules
    {
        public static IReadOnlyList<Rule> All = new[]
        {
            new Rule(@"(?<=^[A-Z])\.(?=,?\s)", "∯"),
            new Rule(@"(?<=\s[A-Z])\.(?=,?\s)", "∯")
        };
    }
}
