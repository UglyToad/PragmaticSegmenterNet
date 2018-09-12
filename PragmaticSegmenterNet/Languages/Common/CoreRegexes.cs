namespace PragmaticSegmenterNet.Languages.Common
{
    using System.Text.RegularExpressions;

    internal static class CoreRegexes
    {
        public static Regex MultiPeriodAbbreviationRegex = new Regex(@"\b[a-z](?:\.[a-z])+[.]", RegexOptions.IgnoreCase);

        public static Regex ContinuousPunctuationRegex = new Regex(@"(?<=\S)(!|\?){3,}(?=(\s|\z|$))");

        public static Regex ParenthesesBetweenDoubleQuotesRegex = new Regex(@"[""”]\s\(.*\)\s[""“]");

        public static Regex SentenceBoundaryRegex = new Regex(@"\uff08(?:[^\uff09])*\uff09(?=\s?[A-Z])|\u300c(?:[^\u300d])*\u300d(?=\s[A-Z])|\((?:[^\)]){2,}\)(?=\s[A-Z])|'(?:[^'])*[^,]'(?=\s[A-Z])|""(?:[^""])*[^,]""(?=\s[A-Z])|“(?:[^”])*[^,]”(?=\s[A-Z])|\S.*?[。．.！!?？ȸȹ☉☈☇☄]");
        
        public static Regex QuotationAtEndOfSentenceRegex = new Regex(@"[!?\.-][\""\'\u201d\u201c]\s{1}[A-Z]");

        public static Regex SplitSpaceQuotationAtEndOfSentenceRegex = new Regex(@"(?<=[!?\.-][\""\'\u201d\u201c])\s{1}(?=[A-Z])");
    }
}