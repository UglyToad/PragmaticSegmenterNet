namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class ArmenianLanguageTests
    {
        [Fact]
        public void SentenceEndingPunctuation001()
        {
            var result = Segmenter.Segment("Ի՞նչ ես մտածում: Ոչինչ:", Language.Armenian);
            Assert.Equal(new[] { "Ի՞նչ ես մտածում:", "Ոչինչ:" }, result);
        }

        [Fact]
        public void Ellipsis002()
        {
            var result = Segmenter.Segment("Ապրիլի 24-ին սկսեց անձրևել...Այդպես էի գիտեի:", Language.Armenian);
            Assert.Equal(new[] { "Ապրիլի 24-ին սկսեց անձրևել...Այդպես էի գիտեի:" }, result);
        }

        [Fact]
        public void PeriodIsNotASentenceBoundary003()
        {
            var result = Segmenter.Segment("Այսպիսով` մոտենում ենք ավարտին: Տրամաբանությյունը հետևյալն է. պարզություն և աշխատանք:", Language.Armenian);
            Assert.Equal(new[] { "Այսպիսով` մոտենում ենք ավարտին:", "Տրամաբանությյունը հետևյալն է. պարզություն և աշխատանք:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment("Սա այն փուլն է, երբ տեղի է ունենում Համակարգի մշակումը: Համաձայն Փուլ 2-ի, Մատակարարը մշակում և/կամ հարմարեցնում է համապատասխան ծրագիրը, տեղադրում ծրագրի բաղկացուցիչները, կատարում առանձին բլոկի և համակարգի թեստավորում և ներառում տարբեր մոդուլներ եզակի աշխատանքային համակարգում, որը  կազմում է այս Փուլի արդյունքը:", Language.Armenian);
            Assert.Equal(new[] { "Սա այն փուլն է, երբ տեղի է ունենում Համակարգի մշակումը:", "Համաձայն Փուլ 2-ի, Մատակարարը մշակում և/կամ հարմարեցնում է համապատասխան ծրագիրը, տեղադրում ծրագրի բաղկացուցիչները, կատարում առանձին բլոկի և համակարգի թեստավորում և ներառում տարբեր մոդուլներ եզակի աշխատանքային համակարգում, որը  կազմում է այս Փուլի արդյունքը:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText002()
        {
            var result = Segmenter.Segment("Մատակարարի նախագծի անձնակազմի կողմից համակարգի թեստերը հաջող անցնելուց հետո, Համակարգը տրվում է Գնորդին թեստավորման համար: 2-րդ փուլում, հիմք ընդունելով թեստային սցենարիոները, թեստերը կատարվում են Կառավարության կողմից Մատակարարի աջակցությամբ: Այս թեստերի թիրախը հանդիսանում է  Համակարգի` որպես մեկ ամբողջության և համակարգի գործունեության ստուգումը համաձայն տեխնիկական բնութագրերի: Այս թեստերի հաջողակ ավարտից հետո, Համակարգը ժամանակավոր ընդունվում է  Կառավարության կողմից: Այս թեստերի արդյունքները փաստաթղթային ձևով կներակայացվեն Թեստային Արդյունքների Հաշվետվություններում: Մատակարարը պետք է տրամադրի հետևյալը`", Language.Armenian);
            Assert.Equal(new[] { "Մատակարարի նախագծի անձնակազմի կողմից համակարգի թեստերը հաջող անցնելուց հետո, Համակարգը տրվում է Գնորդին թեստավորման համար:", "2-րդ փուլում, հիմք ընդունելով թեստային սցենարիոները, թեստերը կատարվում են Կառավարության կողմից Մատակարարի աջակցությամբ:", "Այս թեստերի թիրախը հանդիսանում է  Համակարգի` որպես մեկ ամբողջության և համակարգի գործունեության ստուգումը համաձայն տեխնիկական բնութագրերի:", "Այս թեստերի հաջողակ ավարտից հետո, Համակարգը ժամանակավոր ընդունվում է  Կառավարության կողմից:", "Այս թեստերի արդյունքները փաստաթղթային ձևով կներակայացվեն Թեստային Արդյունքների Հաշվետվություններում:", "Մատակարարը պետք է տրամադրի հետևյալը`" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText003()
        {
            var result = Segmenter.Segment("Մատակարարի նախագծի անձնակազմի կողմից համակարգի թեստերը հաջող անցնելուց հետո, Համակարգը տրվում է Գնորդին թեստավորման համար: 2-րդ փուլում, հիմք ընդունելով թեստային սցենարիոները, թեստերը կատարվում են Կառավարության կողմից Մատակարարի աջակցությամբ: Այս թեստերի թիրախը հանդիսանում է  Համակարգի` որպես մեկ ամբողջության և համակարգի գործունեության ստուգումը համաձայն տեխնիկական բնութագրերի: Այս թեստերի հաջողակ ավարտից հետո, Համակարգը ժամանակավոր ընդունվում է  Կառավարության կողմից: Այս թեստերի արդյունքները փաստաթղթային ձևով կներակայացվեն Թեստային Արդյունքների Հաշվետվություններում: Մատակարարը պետք է տրամադրի հետևյալը`", Language.Armenian);
            Assert.Equal(new[] { "Մատակարարի նախագծի անձնակազմի կողմից համակարգի թեստերը հաջող անցնելուց հետո, Համակարգը տրվում է Գնորդին թեստավորման համար:", "2-րդ փուլում, հիմք ընդունելով թեստային սցենարիոները, թեստերը կատարվում են Կառավարության կողմից Մատակարարի աջակցությամբ:", "Այս թեստերի թիրախը հանդիսանում է  Համակարգի` որպես մեկ ամբողջության և համակարգի գործունեության ստուգումը համաձայն տեխնիկական բնութագրերի:", "Այս թեստերի հաջողակ ավարտից հետո, Համակարգը ժամանակավոր ընդունվում է  Կառավարության կողմից:", "Այս թեստերի արդյունքները փաստաթղթային ձևով կներակայացվեն Թեստային Արդյունքների Հաշվետվություններում:", "Մատակարարը պետք է տրամադրի հետևյալը`" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText004()
        {
            var result = Segmenter.Segment("Բարև Ձեզ: Իմ անունն էԱրմինե:", Language.Armenian);
            Assert.Equal(new[] { "Բարև Ձեզ:", "Իմ անունն էԱրմինե:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText005()
        {
            var result = Segmenter.Segment("Այսօր երկուշաբթի է: Ես գնում եմ աշխատանքի:", Language.Armenian);
            Assert.Equal(new[] { "Այսօր երկուշաբթի է:", "Ես գնում եմ աշխատանքի:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText006()
        {
            var result = Segmenter.Segment("Վաղը սեպտեմբերի 1-ն է: Մենք գնում ենք դպրոց:", Language.Armenian);
            Assert.Equal(new[] { "Վաղը սեպտեմբերի 1-ն է:", "Մենք գնում ենք դպրոց:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText007()
        {
            var result = Segmenter.Segment("Այո, ես հասկացա: Ես իսկապես քեզ սիրում եմ:", Language.Armenian);
            Assert.Equal(new[] { "Այո, ես հասկացա:", "Ես իսկապես քեզ սիրում եմ:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText008()
        {
            var result = Segmenter.Segment("Փակիր պատուհանները: Երեկոյան անձրևում է:", Language.Armenian);
            Assert.Equal(new[] { "Փակիր պատուհանները:", "Երեկոյան անձրևում է:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText009()
        {
            var result = Segmenter.Segment("Մութ է: Ես պետք է տուն վերադառնամ:", Language.Armenian);
            Assert.Equal(new[] { "Մութ է:", "Ես պետք է տուն վերադառնամ:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText010()
        {
            var result = Segmenter.Segment("Գիտես, սկսել եմ հավատալ: Ամեն ինչ փոխվում է:", Language.Armenian);
            Assert.Equal(new[] { "Գիտես, սկսել եմ հավատալ:", "Ամեն ինչ փոխվում է:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText011()
        {
            var result = Segmenter.Segment("Տոնածառը նոր է: Պետք է այն զարդարել:", Language.Armenian);
            Assert.Equal(new[] { "Տոնածառը նոր է:", "Պետք է այն զարդարել:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText012()
        {
            var result = Segmenter.Segment("Ես շտապում եմ: Ես քեզ չեմ կարող սպասել:", Language.Armenian);
            Assert.Equal(new[] { "Ես շտապում եմ:", "Ես քեզ չեմ կարող սպասել:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText013()
        {
            var result = Segmenter.Segment("Սպասիր, մենք իրար սիրում ենք: Ցանկանում եմ միասին ապրենք:", Language.Armenian);
            Assert.Equal(new[] { "Սպասիր, մենք իրար սիրում ենք:", "Ցանկանում եմ միասին ապրենք:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText014()
        {
            var result = Segmenter.Segment("Ոչ, այդպես չեմ կարծում: Դա ճիշտ չէ:", Language.Armenian);
            Assert.Equal(new[] { "Ոչ, այդպես չեմ կարծում:", "Դա ճիշտ չէ:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText015()
        {
            var result = Segmenter.Segment("Ապրիլի 24-ին սկսեց անձրևել...Այդպես էի գիտեի:", Language.Armenian);
            Assert.Equal(new[] { "Ապրիլի 24-ին սկսեց անձրևել...Այդպես էի գիտեի:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText016()
        {
            var result = Segmenter.Segment("1960 թվական…ձմեռ…գիշեր: Սառն էր…դատարկություն:", Language.Armenian);
            Assert.Equal(new[] { "1960 թվական…ձմեռ…գիշեր:", "Սառն էր…դատարկություն:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText017()
        {
            var result = Segmenter.Segment("Ինչ՟ու այն, ինչ անում է մարդը, չի կարող անել համակարգիչը: Պարզապես չունի մարդկային ուղեղ:", Language.Armenian);
            Assert.Equal(new[] { "Ինչ՟ու այն, ինչ անում է մարդը, չի կարող անել համակարգիչը:", "Պարզապես չունի մարդկային ուղեղ:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText018()
        {
            var result = Segmenter.Segment("Թվարկիր ինձ համար 3 բան, որ կարևոր է քեզ համար - Պատասխանում եմ. սեր, գիտելիք, ազնվություն:", Language.Armenian);
            Assert.Equal(new[] { "Թվարկիր ինձ համար 3 բան, որ կարևոր է քեզ համար - Պատասխանում եմ. սեր, գիտելիք, ազնվություն:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText019()
        {
            var result = Segmenter.Segment("Այսպիսով` մոտենում ենք ավարտին: Տրամաբանությյունը հետևյալն է. պարզություն և աշխատանք:", Language.Armenian);
            Assert.Equal(new[] { "Այսպիսով` մոտենում ենք ավարտին:", "Տրամաբանությյունը հետևյալն է. պարզություն և աշխատանք:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText020()
        {
            var result = Segmenter.Segment("Ի՞նչ ես մտածում: Ոչինչ:", Language.Armenian);
            Assert.Equal(new[] { "Ի՞նչ ես մտածում:", "Ոչինչ:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText021()
        {
            var result = Segmenter.Segment("Կարող ե՞նք միասին աշխատել: Գուցե այն ինչ մտածում ես, իրականանալի է:", Language.Armenian);
            Assert.Equal(new[] { "Կարող ե՞նք միասին աշխատել:", "Գուցե այն ինչ մտածում ես, իրականանալի է:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText022()
        {
            var result = Segmenter.Segment("Հիմա, այն ինչ սկսել ենք, ավարտին է մոտենում: Հարցերը սակայն շատ են...:", Language.Armenian);
            Assert.Equal(new[] { "Հիմա, այն ինչ սկսել ենք, ավարտին է մոտենում:", "Հարցերը սակայն շատ են...:" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText023()
        {
            var result = Segmenter.Segment("Սիրելիս...սպասում եմ: Գնամ թ՟ե …:", Language.Armenian);
            Assert.Equal(new[] { "Սիրելիս...սպասում եմ:", "Գնամ թ՟ե …:" }, result);
        }


    }
}
