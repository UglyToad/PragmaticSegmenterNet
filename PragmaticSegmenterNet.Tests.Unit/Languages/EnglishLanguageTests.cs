namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Xunit;

    public class EnglishLanguageTests
    {
        [Fact]
        public void SimplePeriodToEndSentence001()
        {
            var result = Segmenter.Segment("Hello World. My name is Jonas.");

            Assert.Equal(new[] { "Hello World.", "My name is Jonas." }, result);
        }

        [Fact]
        public void QuestionMarkToEndSentence002()
        {
            var result = Segmenter.Segment("What is your name? My name is Jonas.");

            Assert.Equal(new[] { "What is your name?", "My name is Jonas." }, result);
        }

        [Fact]
        public void ExclamationMarkToEndSentence003()
        {
            var result = Segmenter.Segment("There it is! I found it.");

            Assert.Equal(new[] { "There it is!", "I found it." }, result);
        }

        [Fact]
        public void OneLetterUpperCaseAbbreviations004()
        {
            var result = Segmenter.Segment("My name is Jonas E. Smith.");

            Assert.Equal(new[] { "My name is Jonas E. Smith." }, result);
        }

        [Fact]
        public void OneLetterLowerCaseAbbreviations005()
        {
            var result = Segmenter.Segment("Please turn to p. 55.");

            Assert.Equal(new[] { "Please turn to p. 55." }, result);
        }

        [Fact]
        public void TwoLetterLowerCaseAbbreviationsInTheMiddleOfASentence006()
        {
            var result = Segmenter.Segment("Were Jane and co. at the party?");

            Assert.Equal(new[] { "Were Jane and co. at the party?" }, result);

            result = Segmenter.Segment("In Eq. 2, i stands for the year counter.");

            Assert.Equal(new[] { "In Eq. 2, i stands for the year counter." }, result);
        }

        [Fact]
        public void TwoLetterUpperCaseAbbreviationsInTheMiddleOfASentence007()
        {
            var result = Segmenter.Segment("They closed the deal with Pitt, Briggs & Co. at noon.");

            Assert.Equal(new[] { "They closed the deal with Pitt, Briggs & Co. at noon." }, result);
        }

        [Fact]
        public void TwoLetterLowerCaseAbbreviationsAtTheEndOfASentence008()
        {
            var result = Segmenter.Segment("Let's ask Jane and co. They should know.");

            Assert.Equal(new[] { "Let's ask Jane and co.", "They should know." }, result);
        }

        [Fact]
        public void TwoLetterUpperCaseAbbreviationsAtTheEndOfASentence009()
        {
            var result = Segmenter.Segment("They closed the deal with Pitt, Briggs & Co. It closed yesterday.");
            Assert.Equal(new[] { "They closed the deal with Pitt, Briggs & Co.", "It closed yesterday." }, result);
        }

        [Fact]
        public void TwoLetterPrepositiveAbbreviations010()
        {
            var result = Segmenter.Segment("I can see Mt. Fuji from here.");
            Assert.Equal(new[] { "I can see Mt. Fuji from here." }, result);
        }

        [Fact]
        public void TwoLetterPrepositiveAndPostPositiveAbbreviations011()
        {
            var result = Segmenter.Segment("St. Michael's Church is on 5th st. near the light.");
            Assert.Equal(new[] { "St. Michael's Church is on 5th st. near the light." }, result);
        }

        [Fact]
        public void PossesiveTwoLetterAbbreviations012()
        {
            var result = Segmenter.Segment("That is JFK Jr.'s book.");
            Assert.Equal(new[] { "That is JFK Jr.'s book." }, result);
        }

        [Fact]
        public void MultiperiodAbbreviationsInTheMiddleOfASentence013()
        {
            var result = Segmenter.Segment("I visited the U.S.A. last year.");
            Assert.Equal(new[] { "I visited the U.S.A. last year." }, result);
        }

        [Fact]
        public void MultiperiodAbbreviationsAtTheEndOfASentence014()
        {
            var result = Segmenter.Segment("I live in the E.U. How about you?");
            Assert.Equal(new[] { "I live in the E.U.", "How about you?" }, result);
        }

        [Fact]
        public void UsAsSentenceBoundary015()
        {
            var result = Segmenter.Segment("I live in the U.S. How about you?");
            Assert.Equal(new[] { "I live in the U.S.", "How about you?" }, result);
        }

        [Fact]
        public void UsAsNonSentenceBoundaryWithNextWordCapitalized016()
        {
            var result = Segmenter.Segment("I work for the U.S. Government in Virginia.");
            Assert.Equal(new[] { "I work for the U.S. Government in Virginia." }, result);
        }

        [Fact]
        public void UsAsNonSentenceBoundary017()
        {
            var result = Segmenter.Segment("I have lived in the U.S. for 20 years.");
            Assert.Equal(new[] { "I have lived in the U.S. for 20 years." }, result);
        }

        [Fact(Skip = "Not implemented yet")]
        public void AmPmAsNonSentenceBoundaryAndSentenceBoundary018()
        {
            var result = Segmenter.Segment("At 5 a.m. Mr. Smith went to the bank. He left the bank at 6 P.M. Mr. Smith then went to the store.");
            Assert.Equal(new[] { "At 5 a.m. Mr. Smith went to the bank.", "He left the bank at 6 P.M.", "Mr. Smith then went to the store." }, result);
        }

        [Fact]
        public void NumberAsNonSentenceBoundary019()
        {
            var result = Segmenter.Segment("She has $100.00 in her bag.");
            Assert.Equal(new[] { "She has $100.00 in her bag." }, result);
        }

        [Fact]
        public void NumberAsSentenceBoundary020()
        {
            var result = Segmenter.Segment("She has $100.00. It is in her bag.");
            Assert.Equal(new[] { "She has $100.00.", "It is in her bag." }, result);
        }

        [Fact]
        public void ParentheticalInsideSentence021()
        {
            var result = Segmenter.Segment("He teaches science (He previously worked for 5 years as an engineer.) at the local University.");
            Assert.Equal(new[] { "He teaches science (He previously worked for 5 years as an engineer.) at the local University." }, result);
        }

        [Fact]
        public void EmailAddresses022()
        {
            var result = Segmenter.Segment("Her email is Jane.Doe@example.com. I sent her an email.");
            Assert.Equal(new[] { "Her email is Jane.Doe@example.com.", "I sent her an email." }, result);
        }

        [Fact]
        public void WebAddresses023()
        {
            var result = Segmenter.Segment("The site is: https://www.example.50.com/new-site/awesome_content.html. Please check it out.");
            Assert.Equal(new[] { "The site is: https://www.example.50.com/new-site/awesome_content.html.", "Please check it out." }, result);
        }

        [Fact]
        public void SingleQuotationsInsideSentence024()
        {
            var result = Segmenter.Segment("She turned to him, 'This is great.' she said.");
            Assert.Equal(new[] { "She turned to him, 'This is great.' she said." }, result);
        }

        [Fact]
        public void DoubleQuotationsInsideSentence025()
        {
            var result = Segmenter.Segment("She turned to him, \"This is great.\" she said.");
            Assert.Equal(new[] { "She turned to him, \"This is great.\" she said." }, result);
        }

        [Fact]
        public void DoubleQuotationsAtTheEndOfASentence026()
        {
            var result = Segmenter.Segment("She turned to him, \"This is great.\" She held the book out to show him.");
            Assert.Equal(new[] { "She turned to him, \"This is great.\"", "She held the book out to show him." }, result);
        }

        [Fact]
        public void DoublePunctuationExclamationPoint027()
        {
            var result = Segmenter.Segment("Hello!! Long time no see.");
            Assert.Equal(new[] { "Hello!!", "Long time no see." }, result);
        }

        [Fact]
        public void DoublePunctuationQuestionMark028()
        {
            var result = Segmenter.Segment("Hello?? Who is there?");
            Assert.Equal(new[] { "Hello??", "Who is there?" }, result);
        }

        [Fact]
        public void DoublePunctuationExclamationPointQuestionMark029()
        {
            var result = Segmenter.Segment("Hello!? Is that you?");
            Assert.Equal(new[] { "Hello!?", "Is that you?" }, result);
        }

        [Fact]
        public void DoublePunctuationQuestionMarkExclamationPoint030()
        {
            var result = Segmenter.Segment("Hello?! Is that you?");
            Assert.Equal(new[] { "Hello?!", "Is that you?" }, result);
        }

        [Fact]
        public void ListPeriodFollowedByParensAndNoPeriodToEndItem031()
        {
            var result = Segmenter.Segment("1.) The first item 2.) The second item");
            Assert.Equal(new[] { "1.) The first item", "2.) The second item" }, result);
        }

        [Fact]
        public void ListPeriodFollowedByParensAndPeriodToEndItem032()
        {
            var result = Segmenter.Segment("1.) The first item. 2.) The second item.");
            Assert.Equal(new[] { "1.) The first item.", "2.) The second item." }, result);
        }

        [Fact]
        public void ListParensAndNoPeriodToEndItem033()
        {
            var result = Segmenter.Segment("1) The first item 2) The second item");
            Assert.Equal(new[] { "1) The first item", "2) The second item" }, result);
        }

        [Fact]
        public void ListParensAndPeriodToEndItem034()
        {
            var result = Segmenter.Segment("1) The first item. 2) The second item.");
            Assert.Equal(new[] { "1) The first item.", "2) The second item." }, result);
        }

        [Fact]
        public void ListPeriodToMarkListAndNoPeriodToEndItem035()
        {
            var result = Segmenter.Segment("1. The first item 2. The second item");
            Assert.Equal(new[] { "1. The first item", "2. The second item" }, result);
        }

        [Fact]
        public void ListPeriodToMarkListAndPeriodToEndItem036()
        {
            var result = Segmenter.Segment("1. The first item. 2. The second item.");
            Assert.Equal(new[] { "1. The first item.", "2. The second item." }, result);
        }

        [Fact]
        public void ListWithBullet037()
        {
            var result = Segmenter.Segment("• 9. The first item • 10. The second item");
            Assert.Equal(new[] { "• 9. The first item", "• 10. The second item" }, result);
        }

        [Fact]
        public void ListWithHyphen038()
        {
            var result = Segmenter.Segment("⁃9. The first item ⁃10. The second item");
            Assert.Equal(new[] { "⁃9. The first item", "⁃10. The second item" }, result);
        }

        [Fact]
        public void AlphabeticalList039()
        {
            var result = Segmenter.Segment("a. The first item b. The second item c. The third list item");
            Assert.Equal(new[] { "a. The first item", "b. The second item", "c. The third list item" }, result);
        }

        [Fact]
        public void ErrantNewlinesInTheMiddleOfSentencesPdf040()
        {
            var result = Segmenter.Segment("This is a sentence\ncut off in the middle because pdf.", documentType: DocumentType.Pdf);
            Assert.Equal(new[] { "This is a sentence cut off in the middle because pdf." }, result);
        }

        [Fact]
        public void ErrantNewlinesInTheMiddleOfSentences041()
        {
            var result = Segmenter.Segment("It was a cold \nnight in the city.");
            Assert.Equal(new[] { "It was a cold night in the city." }, result);
        }

        [Fact]
        public void LowerCaseListSeparatedByNewline042()
        {
            var result = Segmenter.Segment("features\ncontact manager\nevents, activities\n");
            Assert.Equal(new[] { "features", "contact manager", "events, activities" }, result);
        }

        [Fact]
        public void GeoCoordinates043()
        {
            var result = Segmenter.Segment("You can find it at N°. 1026.253.553. That is where the treasure is.");
            Assert.Equal(new[] { "You can find it at N°. 1026.253.553.", "That is where the treasure is." }, result);
        }

        [Fact]
        public void NamedEntitiesWithAnExclamationPoint044()
        {
            var result = Segmenter.Segment("She works at Yahoo! in the accounting department.");
            Assert.Equal(new[] { "She works at Yahoo! in the accounting department." }, result);
        }

        [Fact]
        public void IasASentenceBoundaryAndIAsAnAbbreviation045()
        {
            var result = Segmenter.Segment("We make a good team, you and I. Did you see Albert I. Jones yesterday?");
            Assert.Equal(new[] { "We make a good team, you and I.", "Did you see Albert I. Jones yesterday?" }, result);
        }

        [Fact]
        public void EllipsisAtEndOfQuotation046()
        {
            var result = Segmenter.Segment("Thoreau argues that by simplifying one’s life, “the laws of the universe will appear less complex. . . .”");
            Assert.Equal(new[] { "Thoreau argues that by simplifying one’s life, “the laws of the universe will appear less complex. . . .”" }, result);
        }

        [Fact]
        public void EllipsisWithSquareBrackets047()
        {
            var result = Segmenter.Segment("\"Bohr [...] used the analogy of parallel stairways [...]\" (Smith 55).");
            Assert.Equal(new[] { "\"Bohr [...] used the analogy of parallel stairways [...]\" (Smith 55)." }, result);
        }

        [Fact]
        public void EllipsisAsSentenceBoundaryStandardEllipsisRules048()
        {
            var result = Segmenter.Segment("If words are left off at the end of a sentence, and that is all that is omitted, indicate the omission with ellipsis marks (preceded and followed by a space) and then indicate the end of the sentence with a period . . . . Next sentence.");
            Assert.Equal(new[] { "If words are left off at the end of a sentence, and that is all that is omitted, indicate the omission with ellipsis marks (preceded and followed by a space) and then indicate the end of the sentence with a period . . . .", "Next sentence." }, result);
        }

        [Fact]
        public void EllipsisAsSentenceBoundaryNonstandardEllipsisRules049()
        {
            var result = Segmenter.Segment("I never meant that.... She left the store.");
            Assert.Equal(new[] { "I never meant that....", "She left the store." }, result);
        }

        [Fact]
        public void EllipsisAsNonSentenceBoundary050()
        {
            var result = Segmenter.Segment("I wasn’t really ... well, what I mean...see . . . what I'm saying, the thing is . . . I didn’t mean it.");
            Assert.Equal(new[] { "I wasn’t really ... well, what I mean...see . . . what I'm saying, the thing is . . . I didn’t mean it." }, result);
        }

        [Fact]
        public void FourDotEllipsis051()
        {
            var result = Segmenter.Segment("One further habit which was somewhat weakened . . . was that of combining words into self-interpreting compounds. . . . The practice was not abandoned. . . .");
            Assert.Equal(new[] { "One further habit which was somewhat weakened . . . was that of combining words into self-interpreting compounds.", ". . . The practice was not abandoned. . . ." }, result);
        }

        [Fact]
        public void NoWhitespaceInBetweenSentences052()
        {
            var result = Segmenter.Segment("Hello world.Today is Tuesday.Mr. Smith went to the store and bought 1,000.That is a lot.");
            Assert.Equal(new[] { "Hello world.", "Today is Tuesday.", "Mr. Smith went to the store and bought 1,000.", "That is a lot." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText083()
        {
            var result = Segmenter.Segment("The nurse gave him the i.v. in his vein. She gave him the i.v. It was a great I.V. that she gave him. She gave him the I.V. It was night.");
            Assert.Equal(new[] { "The nurse gave him the i.v. in his vein.", "She gave him the i.v.", "It was a great I.V. that she gave him.", "She gave him the I.V.", "It was night." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText084()
        {
            var result = Segmenter.Segment("(i) Hello world. \n(ii) Hello world.\n(iii) Hello world.\n(iv) Hello world.\n(v) Hello world.\n(vi) Hello world.");
            Assert.Equal(new[] { "(i) Hello world.", "(ii) Hello world.", "(iii) Hello world.", "(iv) Hello world.", "(v) Hello world.", "(vi) Hello world." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText085()
        {
            var result = Segmenter.Segment("i) Hello world. \nii) Hello world.\niii) Hello world.\niv) Hello world.\nv) Hello world.\nvi) Hello world.");
            Assert.Equal(new[] { "i) Hello world.", "ii) Hello world.", "iii) Hello world.", "iv) Hello world.", "v) Hello world.", "vi) Hello world." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText086()
        {
            var result = Segmenter.Segment("(a) Hello world. (b) Hello world. (c) Hello world. (d) Hello world. (e) Hello world.\n(f) Hello world.");
            Assert.Equal(new[] { "(a) Hello world.", "(b) Hello world.", "(c) Hello world.", "(d) Hello world.", "(e) Hello world.", "(f) Hello world." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText087()
        {
            var result = Segmenter.Segment("(A) Hello world. \n(B) Hello world.\n(C) Hello world.\n(D) Hello world.\n(E) Hello world.\n(F) Hello world.");
            Assert.Equal(new[] { "(A) Hello world.", "(B) Hello world.", "(C) Hello world.", "(D) Hello world.", "(E) Hello world.", "(F) Hello world." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText088()
        {
            var result = Segmenter.Segment("A) Hello world. \nB) Hello world.\nC) Hello world.\nD) Hello world.\nE) Hello world.\nF) Hello world.");
            Assert.Equal(new[] { "A) Hello world.", "B) Hello world.", "C) Hello world.", "D) Hello world.", "E) Hello world.", "F) Hello world." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText089()
        {
            var result = Segmenter.Segment("The GmbH & Co. KG is a limited partnership with, typically, the sole general partner being a limited liability company.");
            Assert.Equal(new[] { "The GmbH & Co. KG is a limited partnership with, typically, the sole general partner being a limited liability company." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText090()
        {
            var result = Segmenter.Segment("[?][footnoteRef:6] This is a footnote.");
            Assert.Equal(new[] { "[?][footnoteRef:6] This is a footnote." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText091()
        {
            var result = Segmenter.Segment("[15:  12:32]  [16:  firma? 13:28]");
            Assert.Equal(new[] { "[15:  12:32]  [16:  firma? 13:28]" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText092()
        {
            var result = Segmenter.Segment("\"It's a good thing that the water is really calm,\" I answered ironically.");
            Assert.Equal(new[] { "\"It's a good thing that the water is really calm,\" I answered ironically." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText093()
        {
            var result = Segmenter.Segment("December 31, 1988. Hello world. It's great! \nBorn April 05, 1989.");
            Assert.Equal(new[] { "December 31, 1988.", "Hello world.", "It's great!", "Born April 05, 1989." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText095()
        {
            var result = Segmenter.Segment("\"Dear, dear! How queer everything is to-day! And yesterday things went on just as usual. _Was_ I the same when I got up this morning? But if I'm not the same, the next question is, 'Who in the world am I?' Ah, _that's_ the great puzzle!\"");
            Assert.Equal(new[] { "\"Dear, dear! How queer everything is to-day! And yesterday things went on just as usual. _Was_ I the same when I got up this morning? But if I'm not the same, the next question is, 'Who in the world am I?' Ah, _that's_ the great puzzle!\"" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText096()
        {
            var result = Segmenter.Segment("Two began, in a low voice, \"Why, the fact is, you see, Miss, this here ought to have been a _red_ rose-tree, and we put a white one in by mistake; and, if the Queen was to find it out, we should all have our heads cut off, you know. So you see, Miss, we're doing our best, afore she comes, to--\" At this moment, Five, who had been anxiously looking across the garden, called out, \"The Queen! The Queen!\" and the three gardeners instantly threw themselves flat upon their faces.");
            Assert.Equal(new[] { "Two began, in a low voice, \"Why, the fact is, you see, Miss, this here ought to have been a _red_ rose-tree, and we put a white one in by mistake; and, if the Queen was to find it out, we should all have our heads cut off, you know. So you see, Miss, we're doing our best, afore she comes, to--\"", "At this moment, Five, who had been anxiously looking across the garden, called out, \"The Queen! The Queen!\" and the three gardeners instantly threw themselves flat upon their faces." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText097()
        {
            var result = Segmenter.Segment("\"Dinah'll miss me very much to-night, I should think!\" (Dinah was the cat.) \"I hope they'll remember her saucer of milk at tea-time. Dinah, my dear, I wish you were down here with me!\"");
            Assert.Equal(new[] { "\"Dinah'll miss me very much to-night, I should think!\"", "(Dinah was the cat.)", "\"I hope they'll remember her saucer of milk at tea-time. Dinah, my dear, I wish you were down here with me!\"" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText098()
        {
            var result = Segmenter.Segment("Hello. 'This is a test of single quotes.' A new sentence.");
            Assert.Equal(new[] { "Hello.", "'This is a test of single quotes.'", "A new sentence." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText099()
        {
            var result = Segmenter.Segment("[A sentence in square brackets.]");
            Assert.Equal(new[] { "[A sentence in square brackets.]" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText100()
        {
            var result = Segmenter.Segment("(iii) List item number 3.");
            Assert.Equal(new[] { "(iii) List item number 3." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText101()
        {
            var result = Segmenter.Segment("Unbelievable??!?!");
            Assert.Equal(new[] { "Unbelievable??!?!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText102()
        {
            var result = Segmenter.Segment("This abbreviation f.e. means for example.");
            Assert.Equal(new[] { "This abbreviation f.e. means for example." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText103()
        {
            var result = Segmenter.Segment("The med. staff here is very kind.");
            Assert.Equal(new[] { "The med. staff here is very kind." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText104()
        {
            var result = Segmenter.Segment("What did you order btw., she wondered.");
            Assert.Equal(new[] { "What did you order btw., she wondered." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText105()
        {
            var result = Segmenter.Segment("SEC. 1262 AUTHORIZATION OF APPROPRIATIONS.");
            Assert.Equal(new[] { "SEC. 1262 AUTHORIZATION OF APPROPRIATIONS." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText106()
        {
            var result = Segmenter.Segment("a");
            Assert.Equal(new[] { "a" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText107()
        {
            var result = Segmenter.Segment("I wrote this in the 'nineties.  It has four sentences.  This is the third, isn't it?  And this is the last");
            Assert.Equal(new[] { "I wrote this in the 'nineties.", "It has four sentences.", "This is the third, isn't it?", "And this is the last" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText108()
        {
            var result = Segmenter.Segment("I wrote this in the ’nineties.  It has four sentences.  This is the third, isn't it?  And this is the last");
            Assert.Equal(new[] { "I wrote this in the ’nineties.", "It has four sentences.", "This is the third, isn't it?", "And this is the last" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText109()
        {
            var result = Segmenter.Segment("He has Ph.D.-level training");
            Assert.Equal(new[] { "He has Ph.D.-level training" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText110()
        {
            var result = Segmenter.Segment("He has Ph.D. level training");
            Assert.Equal(new[] { "He has Ph.D. level training" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText111()
        {
            var result = Segmenter.Segment("I will be paid Rs. 16720/- in total for the time spent and the inconvenience caused to me, only after completion of all aspects of the study.");
            Assert.Equal(new[] { "I will be paid Rs. 16720/- in total for the time spent and the inconvenience caused to me, only after completion of all aspects of the study." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText112()
        {
            var result = Segmenter.Segment("If I decide to withdraw from the study for other reasons, I will be paid only up to the extent of my participation amount according to the approved procedure of Apotex BEC. If I complete all aspects in Period 1, I will be paid Rs. 3520 and if I complete all aspects in Period 1 and Period 2, I will be paid Rs. 7790 and if I complete all aspects in Period 1, Period 2 and Period 3, I will be paid Rs. 12060 at the end of the study.");
            Assert.Equal(new[] { "If I decide to withdraw from the study for other reasons, I will be paid only up to the extent of my participation amount according to the approved procedure of Apotex BEC.", "If I complete all aspects in Period 1, I will be paid Rs. 3520 and if I complete all aspects in Period 1 and Period 2, I will be paid Rs. 7790 and if I complete all aspects in Period 1, Period 2 and Period 3, I will be paid Rs. 12060 at the end of the study." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText113()
        {
            var result = Segmenter.Segment("After completion of each Period, I will be paid an advance amount of rs. 1000 and this amount will be deducted from my final study compensation.");
            Assert.Equal(new[] { "After completion of each Period, I will be paid an advance amount of rs. 1000 and this amount will be deducted from my final study compensation." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText114()
        {
            var result = Segmenter.Segment("Mix it, put it in the oven, and -- voila! -- you have cake.");
            Assert.Equal(new[] { "Mix it, put it in the oven, and -- voila! -- you have cake." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText115()
        {
            var result = Segmenter.Segment("Some can be -- if I may say so? -- a bit questionable.");
            Assert.Equal(new[] { "Some can be -- if I may say so? -- a bit questionable." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText116()
        {
            var result = Segmenter.Segment("What do you see? - Posted like silent sentinels all around the town, stand thousands upon thousands of mortal men fixed in ocean reveries.");
            Assert.Equal(new[] { "What do you see?", "- Posted like silent sentinels all around the town, stand thousands upon thousands of mortal men fixed in ocean reveries." }, result);
        }

        [Fact]
        public void CorrectlyHandlesSinglePeriod()
        {
            var result = Segmenter.Segment(".");
            Assert.Equal(new[] { "." }, result);
        }

        [Fact]
        public void CorrectlyHandlesSingleLetterWithPeriod()
        {
            var result = Segmenter.Segment("A.");
            Assert.Equal(new[] { "A." }, result);
        }

        [Fact]
        public void CorrectlyHandlesExclamationMark()
        {
            var result = Segmenter.Segment("!");
            Assert.Equal(new[] { "!" }, result);
        }

        [Theory]
        [MemberData(nameof(LoadXml))]
        public void DataTests(string input, string[] expected)
        {
            var result = Segmenter.Segment(input);

            for (int i = 0; i < expected.Length; i++)
            {
                var actual = result[i];

                if (expected[i] != actual)
                {
                    Debugger.Break();
                }
            }

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> LoadXml()
        {
            var result = new List<object[]>();

            var baseDirectory = Directory.GetCurrentDirectory();
            var file = Path.Combine(baseDirectory, "Languages", "Data", "EnglishTestData.xml");

            if (!File.Exists(file))
            {
                return result;
            }

            var root = XElement.Load(file);
            var allTests = root.Elements("test");
            
            foreach (var test in allTests)
            {
                if (test.Element("ignored") != null && bool.TryParse(test.Element("ignored")?.Value, out var ignore) && ignore)
                {
                    continue;
                }

                var input = test.Element("input")?.Value;
                var expected = test.Element("expected");
                var sentences = expected?.Elements("sentence");

                result.Add(new object[]
                {
                    input,
                    sentences?.Select(x => x.Value).ToArray()
                });
            }

            return result;
        }
    }
}
