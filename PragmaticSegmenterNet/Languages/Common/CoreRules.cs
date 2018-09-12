namespace PragmaticSegmenterNet.Languages.Common
{
    using System.Text.RegularExpressions;

    internal static class CoreRules
    {
        public static readonly Rule WithMultiplierAndEmailRule = new Rule(@"(\w)(\.)(\w)", @"$1∮$3");

        public static readonly Rule GeoLocationRule = new Rule(@"(?<=[a-zA-z]°)\.(?=\s*\d+)", "∯");

        public static readonly Rule FileFormatRule = new Rule(
            new Regex(@"(?<=\s)\.(?=(jpe?g|png|gif|tiff?|pdf|ps|docx?|xlsx?|svg|bmp|tga|exif|odt|html?|txt|rtf|bat|sxw|xml|zip|exe|msi|blend|wmv|mp[34]|pptx?|flac|rb|cpp|cs|js)\s)"), "∯");

        public static readonly Rule SingleNewLineRule = new Rule("\\n", "ȹ");

        public static readonly Rule PossessiveAbbreviationRule = new Rule(@"\.(?='s\s)|\.(?='s$)|\.(?='s\z)", "∯");

        public static readonly Rule KommanditgesellschaftRule = new Rule(@"(?<=Co)\.(?=\sKG)", "∯");

        public static readonly Rule QuestionMarkInQuotationRule = new Rule(@"\?(?=(\'|\""))", "&ᓷ&");

        public static readonly Rule ExtraWhiteSpaceRule = new Rule(@"\s{3,}", " ");

        public static readonly Rule SubSingleQuoteRule = new Rule("&⎋&", "'");
    }
}