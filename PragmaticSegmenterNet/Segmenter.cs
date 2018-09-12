namespace PragmaticSegmenterNet
{
    using System.Collections.Generic;

    public static class Segmenter
    {
        public static IReadOnlyList<string> Segment(string text, Language language = Language.English, bool cleanText = true, DocumentType documentType = DocumentType.Any)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new string[0];
            }

            var matchingLanguage = LanguageProvider.Get(language);

            if (cleanText)
            {
                text = Cleaner.Clean(text, matchingLanguage, documentType);
            }

            var result = Processor.Process(text, matchingLanguage);

            return result;
        }
    }
}