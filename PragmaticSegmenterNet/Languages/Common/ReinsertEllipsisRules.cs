namespace PragmaticSegmenterNet.Languages.Common
{
    using System.Collections.Generic;

    internal static class ReinsertEllipsisRules
    {
        public static readonly IReadOnlyList<Rule> All = new[]
        {
            // SubThreeConsecutivePeriod
            new Rule("ƪ", "..."),
            // SubThreeSpacePeriod
            new Rule("♟", " . . . "),
            // SubFourSpacePeriod
            new Rule("♝", ". . . ."),
            // SubTwoConsecutivePeriod
            new Rule("☏", ".."),
            // SubOnePeriod
            new Rule("∮", ".")
        };
    }
}
