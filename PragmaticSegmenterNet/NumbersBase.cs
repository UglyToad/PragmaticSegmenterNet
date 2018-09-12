namespace PragmaticSegmenterNet
{
    internal class NumbersBase : INumberRules
    {
        private static readonly Rule[] AllRules = 
        {
            // Period before number rule.
            new Rule(@"\.(?=\d)", Constants.ReplacedSymbol),
            // Number after period before letter rule.
            new Rule(@"(?<=\d)\.(?=\S)", Constants.ReplacedSymbol),
            // Newline number period space letter rule.
            new Rule(@"(?<=\r\d)\.(?=(\s\S)|\))", Constants.ReplacedSymbol),
            // Start line number period rule.
            new Rule(@"(?<=^\d)\.(?=(\s\S)|\))", Constants.ReplacedSymbol),
            // Start line two digit number period rule.
            new Rule(@"(?<=^\d\d)\.(?=(\s\S)|\))", Constants.ReplacedSymbol)
        };

        public string Apply(string input)
        {
            for (var i = 0; i < AllRules.Length; i++)
            {
                var rule = AllRules[i];

                input = rule.Apply(input);
            }

            return input;
        }
    }
}