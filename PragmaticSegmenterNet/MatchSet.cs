namespace PragmaticSegmenterNet
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class MatchSet
    {
        public IEnumerable<Match> Matches => matches;
        public int Count => matches?.Count ?? 0;

        private readonly IReadOnlyList<Match> matches;

        public MatchSet(MatchCollection matchCollection)
        {
            if (matchCollection == null)
            {
                matches = new Match[0];
                return;
            }

            var result = new List<Match>(matchCollection.Count);

            foreach (Match match in matchCollection)
            {
                result.Add(match);
            }

            matches = result;
        }

        public MatchSet(IReadOnlyList<Match> matches)
        {
            this.matches = matches;
        }
    }
}