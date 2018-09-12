namespace PragmaticSegmenterNet.Languages.Common
{
    using System.Collections.Generic;

    internal static class SubSymbolsRules
    {
        public static readonly IReadOnlyList<Rule> All = new[]
        {
            // Period
            new Rule("∯", "."),
            // Arabic comma
            new Rule("♬", "،"),
            // Semi-colon
            new Rule("♭", ":"),
            // Full-width period
            new Rule("&ᓰ&", "。"),
            // Special period
            new Rule("&ᓱ&", "．"),
            // Full-width exclamation mark
            new Rule("&ᓳ&", "！"),
            // Exclamation mark
            new Rule("&ᓴ&", "!"),
            // Question mark
            new Rule("&ᓷ&", "?"),
            // Full-width question mark
            new Rule("&ᓸ&", "？"),
            // Mixed double question exclamation
            new Rule("☉", "?!"),
            // Double question mark
            new Rule("☇", "??"),
            // Double exclamation question
            new Rule("☈", "!?"),
            // Double exclamation mark
            new Rule("☄", "!!"),
            // Left parenthesis
            new Rule("&✂&", "("),
            // Right parenthesis
            new Rule("&⌬&", ")"),
            // Temporary ending
            new Rule("ȸ", string.Empty),
            // Newline
            new Rule("ȹ", "\n")
        };
    }
}
