namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class KazakhLanguageTests
    {
        [Fact]
        public void SimplePeriodToEndSentence001()
        {
            var result = Segmenter.Segment("Мұхитқа тікелей шыға алмайтын мемлекеттердің ішінде Қазақстан - ең үлкені.", Language.Kazakh);
            Assert.Equal(new[] { "Мұхитқа тікелей шыға алмайтын мемлекеттердің ішінде Қазақстан - ең үлкені." }, result);
        }

        [Fact]
        public void QuestionMarkToEndSentence002()
        {
            var result = Segmenter.Segment("Оқушылар үйі, Достық даңғылы, Абай даналығы, ауыл шаруашылығы – кім? не?", Language.Kazakh);
            Assert.Equal(new[] { "Оқушылар үйі, Достық даңғылы, Абай даналығы, ауыл шаруашылығы – кім?", "не?" }, result);
        }

        [Fact]
        public void ParentheticalInsideSentence003()
        {
            var result = Segmenter.Segment("Әр түрлі өлшемнің атауы болып табылатын м (метр), см (сантиметр), кг (киллограмм), т (тонна), га (гектар), ц (центнер), т. б. (тағы басқа), тәрізді белгілер де қысқарған сөздер болып табылады.",
                Language.Kazakh);
            Assert.Equal(new[] { "Әр түрлі өлшемнің атауы болып табылатын м (метр), см (сантиметр), кг (киллограмм), т (тонна), га (гектар), ц (центнер), т. б. (тағы басқа), тәрізді белгілер де қысқарған сөздер болып табылады." }, result);
        }

        [Fact]
        public void TwoLetterAbbreviationToEndSentence004()
        {
            var result = Segmenter.Segment("Мысалы: обкомға (облыстық комитетке) барды, ауаткомда (аудандық атқару комитетінде) болды, педучилищеге (педагогтік училищеге) түсті, медпункттің (медициналық пункттің) алдында т. б.", Language.Kazakh);
            Assert.Equal(new[] { "Мысалы: обкомға (облыстық комитетке) барды, ауаткомда (аудандық атқару комитетінде) болды, педучилищеге (педагогтік училищеге) түсті, медпункттің (медициналық пункттің) алдында т. б." }, result);
        }

        [Fact]
        public void NumberAsNonSentenceBoundary005()
        {
            var result = Segmenter.Segment("Елдің жалпы ішкі өнімі ЖІӨ (номинал) = $225.619 млрд (2014)", Language.Kazakh);
            Assert.Equal(new[] { "Елдің жалпы ішкі өнімі ЖІӨ (номинал) = $225.619 млрд (2014)" }, result);
        }

        [Fact]
        public void NumberAsNonSentenceBoundary006()
        {
            var result = Segmenter.Segment("Б.з.б. 6 – 3 ғасырларда конфуцийшілдік, моизм, легизм мектептерінің қалыптасуы нәтижесінде Қытай философиясы пайда болды.", Language.Kazakh);
            Assert.Equal(new[] { "Б.з.б. 6 – 3 ғасырларда конфуцийшілдік, моизм, легизм мектептерінің қалыптасуы нәтижесінде Қытай философиясы пайда болды." }, result);
        }

        [Fact]
        public void NoWhitespaceBetweenSentences007()
        {
            var result = Segmenter.Segment("Ресейдiң әлеуметтiк-экономикалық жағдайы.XVIII ғасырдың бiрiншi ширегiнде Ресейге тән нәрсе.", Language.Kazakh);
            Assert.Equal(new[] { "Ресейдiң әлеуметтiк-экономикалық жағдайы.", "XVIII ғасырдың бiрiншi ширегiнде Ресейге тән нәрсе." }, result);
        }

        [Fact]
        public void MultiPeriodAbbreviationWithinSentence008()
        {
            var result = Segmenter.Segment("Иран революциясы (1905 — 11) және азаматтық қозғалыс (1918 — 21) кезінде А. Фарахани, М. Кермани, М. Т. Бехар, т.б. ақындар демократиялық идеяның жыршысы болды.", Language.Kazakh);
            Assert.Equal(new[] { "Иран революциясы (1905 — 11) және азаматтық қозғалыс (1918 — 21) кезінде А. Фарахани, М. Кермани, М. Т. Бехар, т.б. ақындар демократиялық идеяның жыршысы болды." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment("Б.з.б. 6 – 3 ғасырларда конфуцийшілдік, моизм, легизм мектептерінің қалыптасуы нәтижесінде Қытай философиясы пайда болды.", Language.Kazakh);
            Assert.Equal(new[] { "Б.з.б. 6 – 3 ғасырларда конфуцийшілдік, моизм, легизм мектептерінің қалыптасуы нәтижесінде Қытай философиясы пайда болды." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText002()
        {
            var result = Segmenter.Segment("'Та марбута' тек сөз соңында екі түрде жазылады:", Language.Kazakh);
            Assert.Equal(new[] { "'Та марбута' тек сөз соңында екі түрде жазылады:" }, result);
        }
    }
}
