namespace PragmaticSegmenterNet.Languages.Common
{
    using System.Collections.Generic;

    internal static class ExclamationMarkRules
    {
        public static readonly IReadOnlyList<Rule> All = new[]
        {
            new Rule(@"\!(?=(\'|\""))", "&ᓴ&"),
            new Rule(@"\!(?=\,\s[a-z])", "&ᓴ&"),
            new Rule(@"\!(?=\s[a-z])", "&ᓴ&")
        };
    }
}
