namespace PragmaticSegmenterNet
{
    using System.Text.RegularExpressions;

    internal static class ReferenceSeparator
    {
        private static readonly char[] TrimChars = {'[', ']'};
        private static readonly Regex ReferenceRegex = new Regex(@"(?<=[^\d\s])(\.|∯)((\[(\d{1,3},?\s?-?\s?)*\b\d{1,3}\])+|((\d{1,3}\s?)*\d{1,3}))(\s)(?=[A-Z])");

        public static string SeparateReferences(string text)
        {
            var result = ReferenceRegex.Replace(text, x =>
            {
                var part = x.Groups[3];

                if (part.Captures.Count <= 1)
                {
                    return Constants.ReplacedSymbol + x.Groups[2].Value + '\r' + x.Groups[7].Value;
                }

                if(!int.TryParse(part.Captures[0].Value.Trim(TrimChars), out var prev))
                {
                    return x.Value;
                }

                for (var i = 1; i < part.Captures.Count; i++)
                {
                    if (!int.TryParse(part.Captures[i].Value.Trim(TrimChars), out var val) || val < prev)
                    {
                        return x.Value;
                    }

                    prev = val;
                }

                return Constants.ReplacedSymbol + x.Groups[2].Value + '\r' + x.Groups[7].Value;
            });

            return result;
        }
    }
}
