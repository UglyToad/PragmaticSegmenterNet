namespace PragmaticSegmenterNet
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal interface ILanguage
    {
        IAbbreviationReplacer AbbreviationReplacer { get; }

        IBetweenPunctuationReplacer BetweenPunctuationReplacer { get; }

        INumberRules NumberRules { get; }
        
        IReadOnlyList<string> Abbreviations { get; }

        IReadOnlyList<string> CleanedAbbreviations { get; }

        IReadOnlyList<string> PrepositiveAbbreviations { get; }

        IReadOnlyList<string> NumberAbbreviations { get; }

        IReadOnlyList<string> SentenceStarters { get; }

        IReadOnlyList<string> Punctuations { get; }

        Regex MultiPeriodAbbreviationRegex { get; }

        Regex ContinuousPunctuationRegex { get; }

        Regex ParenthesesBetweenDoubleQuotesRegex { get; }

        Regex SentenceBoundaryRegex { get; }

        Regex QuotationAtEndOfSentenceRegex { get; }

        Regex SplitSpaceQuotationAtEndOfSentenceRegex { get; }

        IReadOnlyList<Rule> AmPmRules { get; }

        IReadOnlyList<Rule> SingleLetterAbbreviationRules { get; }

        IReadOnlyList<Rule> EllipsisRules { get; }

        IReadOnlyList<Rule> DoublePunctuationRules { get; }

        IReadOnlyList<Rule> ExclamationMarkRules { get; }

        IReadOnlyList<Rule> SubSymbolsRules { get; }

        IReadOnlyList<Rule> ReinsertEllipsisRules { get; }

        Rule WithMultiplePeriodsAndEmailRule { get; }

        Rule GeoLocationRule { get; }

        Rule FileFormatRule { get; }

        Rule SingleNewLineRule { get; }

        Rule PossessiveAbbreviationRule { get; }

        Rule KommanditgesellschaftRule { get; }

        Rule ReplaceColonBetweenNumbersRule { get; }

        Rule ReplaceNonSentenceBoundaryCommaRule { get; }

        Rule QuestionMarkInQuotationRule { get; }

        Rule ExtraWhiteSpaceRule { get; }

        Rule SubSingleQuoteRule { get; }

        ICleanerBehaviour CleanerBehaviour { get; }
    }
}