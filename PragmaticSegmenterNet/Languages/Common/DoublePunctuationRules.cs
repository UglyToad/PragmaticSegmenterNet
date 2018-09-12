namespace PragmaticSegmenterNet.Languages.Common
{
    using System.Collections.Generic;

    internal static class DoublePunctuationRules
    {
        public static readonly IReadOnlyList<Rule> All = new[]
        {
            new Rule(@"\?!", "☉"),
            new Rule(@"!\?", "☈"),
            new Rule(@"\?\?", "☇"),
            new Rule(@"!!", "☄")
        };
    }
}
