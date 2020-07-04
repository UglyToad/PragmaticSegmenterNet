namespace PragmaticSegmenterNet
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal static class ListItemReplacer
    {
        private static readonly IReadOnlyList<string> RomanNumerals = new[]
        {
            "i",
            "ii",
            "iii",
            "iv",
            "v",
            "vi",
            "vii",
            "viii",
            "ix",
            "x",
            "xi",
            "xii",
            "xiii",
            "xiv",
            "x",
            "xi",
            "xii",
            "xiii",
            "xv",
            "xvi",
            "xvii",
            "xviii",
            "xix",
            "xx"
        };

        private static readonly IReadOnlyList<string> LatinNumerals = new[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

        private static readonly Regex AlphabeticalListWithPeriods = new Regex(@"(?<=^)[a-z](?=\.)|(?<=\A)[a-z](?=\.)|(?<=\s)[a-z](?=\.)");
        private static readonly Regex AlphabeticalListWithParens = new Regex(@"(?<=\()[a-z]+(?=\))|(?<=^)[a-z]+(?=\))|(?<=\A)[a-z]+(?=\))|(?<=\s)[a-z]+(?=\))", RegexOptions.IgnoreCase);
        //                                                            /\s\d{1,2}(?=\.\s)|^\d{1,2}(?=\.\s)|\s\d{1,2}(?=\.\))|^\d{1,2}(?=\.\))|(?<=\s\-)\d{1,2}(?=\.\s)|(?<=^\-)\d{1,2}(?=\.\s)|(?<=\s\⁃)\d{1,2}(?=\.\s)|(?<=^\⁃)\d{1,2}(?=\.\s)|(?<=s\-)\d{1,2}(?=\.\))|(?<=^\-)\d{1,2}(?=\.\))|(?<=\s\⁃)\d{1,2}(?=\.\))|(?<=^\⁃)\d{1,2}(?=\.\))/
        private static readonly Regex NumberedListRegex1 = new Regex(@"\s\d{1,2}(?=\.\s)|^\d{1,2}(?=\.\s)|\s\d{1,2}(?=\.\))|^\d{1,2}(?=\.\))|(?<=\s\-)\d{1,2}(?=\.\s)|(?<=^\-)\d{1,2}(?=\.\s)|(?<=\s\⁃)\d{1,2}(?=\.\s)|(?<=^\⁃)\d{1,2}(?=\.\s)|(?<=s\-)\d{1,2}(?=\.\))|(?<=^\-)\d{1,2}(?=\.\))|(?<=\s\⁃)\d{1,2}(?=\.\))|(?<=^\⁃)\d{1,2}(?=\.\))", RegexOptions.Multiline);
        private static readonly Regex NumberedListRegex2 = new Regex(@"(?<=\s)\d{1,2}\.(?=\s)|^\d{1,2}\.(?=\s)|(?<=\s)\d{1,2}\.(?=\))|^\d{1,2}\.(?=\))|(?<=\s\-)\d{1,2}\.(?=\s)|(?<=^\-)\d{1,2}\.(?=\s)|(?<=\s\⁃)\d{1,2}\.(?=\s)|(?<=^\⁃)\d{1,2}\.(?=\s)|(?<=\s\-)\d{1,2}\.(?=\))|(?<=^\-)\d{1,2}\.(?=\))|(?<=\s\⁃)\d{1,2}\.(?=\))|(?<=^\⁃)\d{1,2}\.(?=\))");
        private static readonly Regex NumberedListParensRegex = new Regex(@"\d{1,2}(?=\)\s)");
        private static readonly Regex ExtractAlphabeticalListLettersRegex = new Regex(@"\([a-z]+(?=\))|(?<=^)[a-z]+(?=\))|(?<=\A)[a-z]+(?=\))|(?<=\s)[a-z]+(?=\))", RegexOptions.IgnoreCase);
        private static readonly Regex AlphabeticalListLettersAndPeriodsRegex = new Regex(@"(?<=^)[a-z]\.|(?<=\A)[a-z]\.|(?<=\s)[a-z]\.", RegexOptions.IgnoreCase);
        private static readonly Regex RomanNumeralsInParentheses = new Regex(@"\(((?=[mdclxvi])m*(c[md]|d?c*)(x[cl]|l?x*)(i[xv]|v?i*))\)(?=\s[A-Z])");

        private static readonly Rule SubstituteListPeriodRule = new Rule("♨", "∯");
        private static readonly Rule ListMarkerRule = new Rule("☝", "");
        private static readonly Rule SpaceBetweenListItemsFirstRule = new Rule(@"(?<=\S\S|^)\s(?=\S\s*\d{1,2}♨)", "\r");
        private static readonly Rule SpaceBetweenListItemsSecondRule = new Rule(@"(?<=\S[^\s,:]|^)\s(?=\d{1,2}♨)", "\r");
        private static readonly Rule SpaceBetweenListItemsThirdRule = new Rule(@"(?<=\S\S|^)\s(?=\d{1,2}☝)", "\r");

        public static string AddLineBreak(string text)
        {
            var alphabetical = FormatAlphabeticalLists(text);
            var numeral = FormatRomanNumeralLists(alphabetical);
            var numberedWithPeriods = FormatNumberedListWithPeriods(numeral);
            var result = FormatNumberedListWithParens(numberedWithPeriods);

            return result;
        }

        public static string ReplaceParentheses(string text)
        {
            var result = RomanNumeralsInParentheses.Replace(text, @"&✂&$1&⌬&");

            return result;
        }

        private static string FormatNumberedListWithParens(string text)
        {
            var numberedList = ReplaceParenthesesInNumberedList(text);
            var withLineBreaks = AddLineBreaksForNumberedListWithParentheses(numberedList);
            var result = ListMarkerRule.Apply(withLineBreaks);

            return result;
        }

        private static string FormatNumberedListWithPeriods(string text)
        {
            var numericPeriodsReplaced = ReplacePeriodsInNumberedList(text);
            var withLineBreaks = AddLineBreaksForNumberedListWithPeriods(numericPeriodsReplaced);
            var result = SubstituteListPeriodRule.Apply(withLineBreaks);

            return result;
        }

        private static string FormatAlphabeticalLists(string text)
        {
            var withPeriods = AddLineBreaksForAlphabeticalListWithPeriods(text, false);
            var result = AddLineBreaksForAlphabeticalListWithParentheses(withPeriods, false);

            return result;
        }

        private static string FormatRomanNumeralLists(string text)
        {
            var withPeriods = AddLineBreaksForAlphabeticalListWithPeriods(text, true);
            var result = AddLineBreaksForAlphabeticalListWithParentheses(withPeriods, true);

            return result;
        }

        private static string ReplacePeriodsInNumberedList(string text)
        {
            var result = ScanLists(text, NumberedListRegex1, NumberedListRegex2, "♨", true);

            return result;
        }

        private static readonly Regex SpecialCaseFirstRule = new Regex(@"♨.+(\n|\r).+♨");
        private static readonly Regex ForNumberedItemsText = new Regex(@"for\s\d{1,2}♨\s[a-z]");

        private static string AddLineBreaksForNumberedListWithPeriods(string text)
        {
            if (text.Contains("♨") && !SpecialCaseFirstRule.IsMatch(text) && !ForNumberedItemsText.IsMatch(text))
            {
                var result = SpaceBetweenListItemsFirstRule.Apply(text);
                result = SpaceBetweenListItemsSecondRule.Apply(result);

                return result;
            }

            return text;
        }

        private static string ReplaceParenthesesInNumberedList(string text)
        {
            var firstPass = ScanLists(text, NumberedListParensRegex, NumberedListParensRegex, "☝");
            var result = ScanLists(firstPass, NumberedListParensRegex, NumberedListParensRegex, "☝");

            return result;
        }

        private static readonly Regex SpecialPointyCase = new Regex(@"☝.+\n.+☝|☝.+\r.+☝");
        private static string AddLineBreaksForNumberedListWithParentheses(string text)
        {
            if (text.Contains("☝") && !SpecialPointyCase.IsMatch(text))
            {
                var result = SpaceBetweenListItemsThirdRule.Apply(text);

                return result;
            }

            return text;
        }

        private static string ScanLists(string text, Regex regex1, Regex regex2, string replacement, bool strip = false)
        {
            var matches = regex1.Matches(text);

            var list = new List<int>(matches.Count);

            for (var i = 0; i < matches.Count; i++)
            {
                list.Add(int.Parse(matches[i].Value.Trim()));
            }

            var result = text;

            for (var i = 0; i < list.Count; i++)
            {
                var item = list[i];

                if (i < list.Count - 1 && item + 1 == list[i + 1])
                {
                    result = substitute_found_list_items(result, regex2, item, strip, replacement);
                }
                else if (i > 0)
                {
                    if (item - 1 == list[i - 1]
                    || (item == 0 && list[i - 1] == 9)
                    || (item == 9 && list[i - 1] == 0))
                    {
                        result = substitute_found_list_items(result, regex2, item, strip, replacement);
                    }
                }
            }

            return result;

        }

        private static string substitute_found_list_items(string text, Regex regex, int item, bool strip, string replacement)
        {
            var result = regex.Replace(text, match =>
            {
                var compareTo = strip ? Chop(match.Value.Trim()) : match.Value;

                var itemString = item.ToString();

                if (itemString == compareTo)
                {
                    var escaped = Regex.Escape(itemString) + replacement;

                    return escaped;
                }

                return match.Value;
            });

            return result;
        }

        private static string AddLineBreaksForAlphabeticalListWithPeriods(string text, bool isRomanNumeral)
        {
            var result = ReplaceItemsFromAlphabetArray(AlphabeticalListWithPeriods, text, isRomanNumeral: isRomanNumeral);

            return result;
        }

        private static string AddLineBreaksForAlphabeticalListWithParentheses(string text, bool isRomanNumeral)
        {
            var result = ReplaceItemsFromAlphabetArray(AlphabeticalListWithParens, text,
                true,
                isRomanNumeral);

            return result;
        }

        private static string ReplaceItemsFromAlphabetArray(Regex regex, string text, bool hasParentheses = false, bool isRomanNumeral = false)
        {
            var matches = regex.Matches(text);
            var listArray = new List<string>(matches.Count);

            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                // TODO: use lower invariant?
                listArray.Add(match.Value.ToLower());
            }

            IReadOnlyList<string> alphabet = isRomanNumeral ? RomanNumerals : LatinNumerals;

            for (int i = 0; i < listArray.Count; i++)
            {
                var item = listArray[i];

                var isInAlphabet = false;
                for (var j = 0; j < alphabet.Count; j++)
                {
                    var alphabetItem = alphabet[j];

                    if (alphabetItem.Contains(item))
                    {
                        isInAlphabet = true;
                        break;
                    }
                }

                if (!isInAlphabet)
                {
                    listArray.Remove(item);
                    i--;
                }
            }

            for (int i = 0; i < listArray.Count; i++)
            {
                if (i == listArray.Count - 1)
                {
                    text = LastArrayItemReplacement(text, listArray[i], i, alphabet, listArray, hasParentheses);
                }
                else
                {
                    text = OtherItemsReplacement(text, listArray[i], i, alphabet, listArray, hasParentheses);
                }
            }

            return text;
        }

        private static string OtherItemsReplacement(string text, string item, int i, IReadOnlyList<string> alphabet, List<string> list, bool hasParentheses)
        {
            if (!TryGetIndex(item, alphabet, out var itemIndex))
            {
                return text;
            }

            var precedingItem = GetRubyIndexed(list, i - 1);

            if (precedingItem == null || !TryGetIndex(precedingItem, alphabet, out var precedingItemIndex))
            {
                return text;
            }

            var followingItem = GetRubyIndexed(list, i + 1);

            if (followingItem == null || !TryGetIndex(followingItem, alphabet, out var followingItemIndex))
            {
                return text;
            }

            var deltaNext = Math.Abs(followingItemIndex - itemIndex);
            var deltaPrev = Math.Abs(itemIndex - precedingItemIndex);

            if (deltaNext != 1 && deltaPrev != 1)
            {
                return text;
            }

            var result = ReplaceCorrectAlphabetList(text, item, hasParentheses);

            return result;
        }

        private static string LastArrayItemReplacement(string text, string item, int i, IReadOnlyList<string> alphabet, List<string> list, bool hasParentheses)
        {
            if (!TryGetIndex(item, alphabet, out var itemIndex))
            {
                return text;
            }

            var precedingItem = GetRubyIndexed(list, i - 1);

            if (precedingItem == null || !TryGetIndex(precedingItem, alphabet, out var precedingItemIndex))
            {
                return text;
            }

            var alphabetSet = new HashSet<string>(alphabet);
            var itemsSet = new HashSet<string>(list);

            itemsSet.IntersectWith(alphabetSet);

            if (itemsSet.Count == 0)
            {
                return text;
            }

            var delta = Math.Abs(precedingItemIndex - itemIndex);

            if (delta != 1)
            {
                return text;
            }

            var result = ReplaceCorrectAlphabetList(text, item, hasParentheses);

            return result;
        }

        private static string ReplaceCorrectAlphabetList(string text, string item, bool hasParentheses)
        {
            if (hasParentheses)
            {
                return ReplaceAlphabetListWithParentheses(text, item);
            }

            return ReplaceAlphabetList(text, item);
        }

        private static string ReplaceAlphabetList(string text, string item)
        {
            var result = AlphabeticalListLettersAndPeriodsRegex.Replace(text, match =>
            {
                if (item != match.Value.TrimEnd('.'))
                {
                    return match.Value;
                }

                var escaped = Regex.Escape(item);

                return $"\r{escaped}∯";
            });

            return result;
        }

        private static readonly Regex OpenParenthesis = new Regex(@"\(");
        private static string ReplaceAlphabetListWithParentheses(string text, string item)
        {
            var result = ExtractAlphabeticalListLettersRegex.Replace(text, match =>
            {
                if (match.Value.Contains("("))
                {
                    var tidied = OpenParenthesis.Replace(match.Value.ToLower(), string.Empty);

                    if (item == tidied)
                    {
                        var escaped = Regex.Escape(OpenParenthesis.Replace(match.Value, string.Empty));

                        return $"\r&✂&{escaped}";
                    }

                    return match.Value;
                }

                var lowercaseMatch = item == match.Value.ToLower();
                if (lowercaseMatch)
                {
                    var escaped = Regex.Escape(match.Value);
                    return "\r" + escaped;
                }

                return match.Value;
            });

            return result;
        }


        private static bool TryGetIndex(string item, IReadOnlyList<string> list, out int index)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] == item)
                {
                    index = i;
                    return true;
                }
            }

            index = -1;
            return false;
        }

        private static string GetRubyIndexed(IReadOnlyList<string> list, int index)
        {
            if (index < 0)
            {
                return list[list.Count + index];
            }

            if (index >= list.Count)
            {
                return null;
            }

            return list[index];
        }

        private static string Chop(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 1)
            {
                return string.Empty;
            }

            if (input.EndsWith("\r\n"))
            {
                return input.Substring(0, input.Length - 2);
            }

            return input.Substring(0, input.Length - 1);
        }
    }
}
