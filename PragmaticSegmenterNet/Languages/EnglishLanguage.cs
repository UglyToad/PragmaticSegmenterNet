namespace PragmaticSegmenterNet.Languages
{
    using System.Collections.Generic;

    internal class EnglishLanguage : LanguageBase
    {
        private static readonly ICleanerBehaviour CleanerBehaviourInstance = new EnglishCleanerBehaviour();

        public override IReadOnlyList<string> SentenceStarters { get; } = new[]
        {
            "A", "Being", "Did", "For", "He", "How", "However", "I", "In", "It", "Millions", "More", "She", "That", "The", "There", "They", "We", "What", "When", "Where", "Who", "Why"
        };

        public override IReadOnlyList<string> CleanedAbbreviations { get; } = new string[0];

        public override ICleanerBehaviour CleanerBehaviour { get; } = CleanerBehaviourInstance;

        private class EnglishCleanerBehaviour : CleanerBehaviourBase
        {
            public override string OnClean(string text)
            {
                return text.Replace('`', '\'');
            }
        }
    }
}
