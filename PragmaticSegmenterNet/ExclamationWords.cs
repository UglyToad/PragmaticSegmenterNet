namespace PragmaticSegmenterNet
{
    using System.Text.RegularExpressions;

    internal static class ExclamationWords
    {
        private static readonly Regex ExclamationRegex =
            new Regex("!Xũ|!Kung|ǃʼOǃKung|!Xuun|!Kung-Ekoka|ǃHu|ǃKhung|ǃKu|ǃung|ǃXo|ǃXû|ǃXung|ǃXũ|!Xun|Yahoo!|Y!J|Yum!");

        public static string Apply(string input)
        {
            var matches = ExclamationRegex.Matches(input);

            var result = PunctuationReplacer.Replace(input, matches);

            return result;
        }
    }
}
