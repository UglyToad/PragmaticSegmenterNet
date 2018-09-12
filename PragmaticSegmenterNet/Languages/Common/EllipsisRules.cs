namespace PragmaticSegmenterNet.Languages.Common
{
    using System.Collections.Generic;

    internal static class EllipsisRules
    {
        public static readonly IReadOnlyList<Rule> All = new[]
        {
            // Three Space Rule.
            new Rule(@"(\s\.){3}\s", "♟"),
            // Four Space Rule
            new Rule(@"(?<=[a-z])(\.\s){3}\.(\z|$|\n)", "♝"),
            // Four Consecutive Rule.
            new Rule(@"(?<=\S)\.{3}(?=\.\s[A-Z])", "ƪ"),
            // Three Consecutive Rule.
            new Rule(@"\.\.\.(?=\s+[A-Z])", "☏."),
            // Other Three Period Rule.
            new Rule(@"\.\.\.", "ƪ")
        };
    }
}
