namespace PragmaticSegmenterNet.Languages
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Common;

    internal class LanguageBase : ILanguage
    {
        protected static IReadOnlyList<string> Empty = new string[0];

        protected static readonly IReadOnlyList<string> SentenceStartersCore = new[]
        {
            "A",
            "Being",
            "Did",
            "For",
            "He",
            "How",
            "However",
            "I",
            "In",
            "It",
            "Millions",
            "More",
            "She",
            "That",
            "The",
            "There",
            "They",
            "We",
            "What",
            "When",
            "Where",
            "Who",
            "Why"
        };

        protected static readonly IReadOnlyList<string> PunctuationsCore = new[]
        {
            "。", "．", ".", "！", "!", "?", "？"
        };
        
        public virtual IAbbreviationReplacer AbbreviationReplacer { get; }
        public virtual IBetweenPunctuationReplacer BetweenPunctuationReplacer { get; } = new BetweenPunctuationReplacer();
        public virtual INumberRules NumberRules { get; }
        public virtual Rule PossessiveAbbreviationRule => CoreRules.PossessiveAbbreviationRule;
        public virtual Rule KommanditgesellschaftRule => CoreRules.KommanditgesellschaftRule;
        public virtual Rule ReplaceColonBetweenNumbersRule => Rule.Empty;
        public virtual Rule ReplaceNonSentenceBoundaryCommaRule => Rule.Empty;
        public virtual Rule QuestionMarkInQuotationRule => CoreRules.QuestionMarkInQuotationRule;
        public virtual Rule ExtraWhiteSpaceRule => CoreRules.ExtraWhiteSpaceRule;
        public virtual Rule SubSingleQuoteRule => CoreRules.SubSingleQuoteRule;

        public virtual Regex QuotationAtEndOfSentenceRegex => CoreRegexes.QuotationAtEndOfSentenceRegex;
        public virtual Regex SplitSpaceQuotationAtEndOfSentenceRegex => CoreRegexes.SplitSpaceQuotationAtEndOfSentenceRegex;
        public virtual IReadOnlyList<Rule> SingleLetterAbbreviationRules => Common.SingleLetterAbbreviationRules.All;
        public virtual IReadOnlyList<string> Abbreviations => CoreAbbreviations.Abbreviations;
        public virtual IReadOnlyList<string> CleanedAbbreviations => Abbreviations;
        public virtual IReadOnlyList<string> PrepositiveAbbreviations => CoreAbbreviations.PrepositiveAbbreviations;
        public virtual IReadOnlyList<string> NumberAbbreviations => CoreAbbreviations.NumberAbbreviations;

        public virtual IReadOnlyList<string> Punctuations => PunctuationsCore;
        public virtual Regex MultiPeriodAbbreviationRegex => CoreRegexes.MultiPeriodAbbreviationRegex;
        public virtual Regex SentenceBoundaryRegex => CoreRegexes.SentenceBoundaryRegex;
        public virtual IReadOnlyList<Rule> AmPmRules => Common.AmPmRules.All;
        public virtual IReadOnlyList<string> SentenceStarters => SentenceStartersCore;
        public virtual Regex ContinuousPunctuationRegex => CoreRegexes.ContinuousPunctuationRegex;
        public virtual IReadOnlyList<Rule> ExclamationMarkRules => Common.ExclamationMarkRules.All;
        public virtual IReadOnlyList<Rule> SubSymbolsRules => Common.SubSymbolsRules.All;
        public virtual IReadOnlyList<Rule> ReinsertEllipsisRules => Common.ReinsertEllipsisRules.All;
        public Rule WithMultiplePeriodsAndEmailRule => CoreRules.WithMultiplierAndEmailRule;
        public Rule GeoLocationRule => CoreRules.GeoLocationRule;
        public Rule FileFormatRule => CoreRules.FileFormatRule;
        public virtual Rule SingleNewLineRule => CoreRules.SingleNewLineRule;
        public virtual IReadOnlyList<Rule> EllipsisRules => Common.EllipsisRules.All;
        public virtual IReadOnlyList<Rule> DoublePunctuationRules => Common.DoublePunctuationRules.All;
        public virtual Regex ParenthesesBetweenDoubleQuotesRegex => CoreRegexes.ParenthesesBetweenDoubleQuotesRegex;
        
        public virtual ICleanerBehaviour CleanerBehaviour { get; } = new CleanerBehaviourBase();

        public LanguageBase()
        {
            AbbreviationReplacer = new AbbreviationReplacerBase(this);
            NumberRules = new NumbersBase();
        }
    }
}