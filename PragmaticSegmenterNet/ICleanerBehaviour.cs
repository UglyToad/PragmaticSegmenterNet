namespace PragmaticSegmenterNet
{
    using System.Text.RegularExpressions;

    internal interface ICleanerBehaviour
    {
        Regex NoSpaceBetweenSentencesRegex { get; }

        Rule NoSpaceBetweenSentencesRule { get; }

        string OnClean(string text);
    }
}