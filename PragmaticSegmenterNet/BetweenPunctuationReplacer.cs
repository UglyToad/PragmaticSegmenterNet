namespace PragmaticSegmenterNet
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// This class handles punctuation between quotes or parenthesis.
    /// </summary>
    internal class BetweenPunctuationReplacer : IBetweenPunctuationReplacer
    {
        private static readonly Regex BetweenSingleQuotesRegex = new Regex(@"(?<=\s)'(?:[^']|'[a-zA-Z])*'");

        private static readonly Regex BetweenSlantedSingleQuotesRegex = new Regex(@"(?<=\s)‘(?:[^’]|’[a-zA-Z])*’");

        private static readonly Regex BetweenDoubleQuotesRegex = new Regex(@"""(?>[^""\\]+|\\{2}|\\.)*""");

        private static readonly Regex BetweenQuoteArrowRegex = new Regex(@"«(?>[^»\\]+|\\{2}|\\.)*»");

        private static readonly Regex BetweenDoubleAngleQuotationMarkRegex = new Regex(@"《(?>[^》\\]+|\\{2}|\\.)*》");

        private static readonly Regex BetweenQuoteSlantedRegex = new Regex(@"“(?>[^”\\]+|\\{2}|\\.)*”");

        private static readonly Regex BetweenSquareBracketsRegex = new Regex(@"\[(?>[^\]\\]+|\\{2}|\\.)*\]");

        private static readonly Regex BetweenParensRegex = new Regex(@"\((?>[^\(\)\\]+|\\{2}|\\.)*\)");

        private static readonly Regex WordWithLeadingApostrophe = new Regex(@"(?<=\s)'(?:[^']|'[a-zA-Z])*'\S");

        private static readonly Regex BetweenEmDashesRegex = new Regex(@"\-\-((?!(\-\-|\.)).)*\-\-");

        private static readonly Regex SpaceFollowingApostropheRegex = new Regex(@"'\s");

        public string Replace(string text)
        {
            var result = SubstitutePunctuationBetweenQuotesAndParens(text);

            return result;
        }

        protected virtual string SubstitutePunctuationBetweenQuotesAndParens(string text)
        {
            text = SubstitutePunctuationBetweenSingleQuotes(text);
            text = SubstituteUsingRegex(BetweenSlantedSingleQuotesRegex, text);
            text = SubstitutePunctuationBetweenDoubleQuotes(text);
            text = SubstituteUsingRegex(BetweenSquareBracketsRegex, text);
            text = SubstituteUsingRegex(BetweenParensRegex, text);
            text = SubstituteUsingRegex(BetweenQuoteArrowRegex, text);
            text = SubstituteUsingRegex(BetweenDoubleAngleQuotationMarkRegex, text);
            text = SubstituteUsingRegex(BetweenEmDashesRegex, text);
            text = SubstituteUsingRegex(BetweenQuoteSlantedRegex, text);

            return text;
        }

        private static string SubstitutePunctuationBetweenSingleQuotes(string txt)
        { 
            if (WordWithLeadingApostrophe.IsMatch(txt) && !SpaceFollowingApostropheRegex.IsMatch(txt))
            {
                return txt;
            }

            var matches = BetweenSingleQuotesRegex.Matches(txt);
            var result = PunctuationReplacer.Replace(txt, matches, PunctuationReplacerType.Single);

            return result;
        }

        private string SubstitutePunctuationBetweenDoubleQuotes(string text)
        {
            var matches = GetTextBetweenDoubleQuotes(text);
            var result = PunctuationReplacer.Replace(text, matches);

            return result;
        }

        protected virtual MatchSet GetTextBetweenDoubleQuotes(string text)
        {
            var result = BetweenDoubleQuotesRegex.Matches(text);
            return new MatchSet(result);
        }
        
        protected static string SubstituteUsingRegex(Regex regex, string text)
        {
            var matches = regex.Matches(text);
            var result = PunctuationReplacer.Replace(text, matches);

            return result;
        }
    }
}