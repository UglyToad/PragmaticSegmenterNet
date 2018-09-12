namespace PragmaticSegmenterNet
{
    using Languages;

    internal static class LanguageProvider
    {
        public static ILanguage Get(Language language)
        {
            switch (language)
            {
                case Language.Amharic:
                    return new AmharicLanguage();
                case Language.Arabic:
                    return new ArabicLanguage();
                case Language.Armenian:
                    return new ArmenianLanguage();
                case Language.Bulgarian:
                    return new BulgarianLanguage();
                case Language.Burmese:
                    return new BurmeseLanguage();
                case Language.Chinese:
                    return new ChineseLanguage();
                case Language.Danish:
                    return new DanishLanguage();
                case Language.Dutch:
                    return new DutchLanguage();
                case Language.English:
                    return new EnglishLanguage();
                case Language.French:
                    return new FrenchLanguage();
                case Language.German:
                    return new GermanLanguage();
                case Language.Greek:
                    return new GreekLanguage();
                case Language.Hindi:
                    return new HindiLanguage();
                case Language.Italian:
                    return new ItalianLanguage();
                case Language.Japanese:
                    return new JapaneseLanguage();
                case Language.Kazakh:
                    return new KazakhLanguage();
                case Language.Persian:
                    return new PersianLanguage();
                case Language.Polish:
                    return new PolishLanguage();
                case Language.Russian:
                    return new RussianLanguage();
                case Language.Spanish:
                    return new SpanishLanguage();
                case Language.Urdu:
                    return new UrduLanguage();
                default:
                    return new LanguageBase();
            }
        }
    }
}