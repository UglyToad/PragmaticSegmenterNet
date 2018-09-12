namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class RussianLanguageTests
    {
        [Fact]
        public void Abbreviations001()
        {
            var result = Segmenter.Segment("Объем составляет 5 куб.м.", Language.Russian);
            Assert.Equal(new[] { "Объем составляет 5 куб.м." }, result);
        }

        [Fact]
        public void Quotations002()
        {
            var result = Segmenter.Segment("Маленькая девочка бежала и кричала: «Не видали маму?».", Language.Russian);
            Assert.Equal(new[] { "Маленькая девочка бежала и кричала: «Не видали маму?»." }, result);
        }

        [Fact]
        public void Numbers003()
        {
            var result = Segmenter.Segment("Сегодня 27.10.14", Language.Russian);
            Assert.Equal(new[] { "Сегодня 27.10.14" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment("Маленькая девочка бежала и кричала: «Не видали маму?».", Language.Russian);
            Assert.Equal(new[] { "Маленькая девочка бежала и кричала: «Не видали маму?»." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText002()
        {
            var result = Segmenter.Segment("«Я приду поздно»,  — сказал Андрей.", Language.Russian);
            Assert.Equal(new[] { "«Я приду поздно»,  — сказал Андрей." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText003()
        {
            var result = Segmenter.Segment("«К чему ты готовишься? – спросила мама. – Завтра ведь выходной».", Language.Russian);
            Assert.Equal(new[] { "«К чему ты готовишься? – спросила мама. – Завтра ведь выходной»." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText004()
        {
            var result = Segmenter.Segment("По словам Пушкина, «Привычка свыше дана, замена счастью она».", Language.Russian);
            Assert.Equal(new[] { "По словам Пушкина, «Привычка свыше дана, замена счастью она»." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText005()
        {
            var result = Segmenter.Segment("Он сказал: «Я очень устал», и сразу же замолчал.", Language.Russian);
            Assert.Equal(new[] { "Он сказал: «Я очень устал», и сразу же замолчал." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText006()
        {
            var result = Segmenter.Segment("Мне стало как-то ужасно грустно в это мгновение; однако что-то похожее на смех зашевелилось в душе моей.", Language.Russian);
            Assert.Equal(new[] { "Мне стало как-то ужасно грустно в это мгновение; однако что-то похожее на смех зашевелилось в душе моей." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText007()
        {
            var result = Segmenter.Segment("Шухов как был в ватных брюках, не снятых на ночь (повыше левого колена их тоже был пришит затасканный, погрязневший лоскут, и на нем выведен черной, уже поблекшей краской номер Щ-854), надел телогрейку…",
                Language.Russian);
      
            Assert.Equal(new[] { "Шухов как был в ватных брюках, не снятых на ночь (повыше левого колена их тоже был пришит затасканный, погрязневший лоскут, и на нем выведен черной, уже поблекшей краской номер Щ-854), надел телогрейку…" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText008()
        {
            var result = Segmenter.Segment("Слово «дом» является синонимом жилища", Language.Russian);
            Assert.Equal(new[] { "Слово «дом» является синонимом жилища" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText009()
        {
            var result = Segmenter.Segment("В Санкт-Петербург на гастроли приехал театр «Современник»", Language.Russian);
            Assert.Equal(new[] { "В Санкт-Петербург на гастроли приехал театр «Современник»" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText010()
        {
            var result = Segmenter.Segment("Машина едет со скоростью 100 км/ч.", Language.Russian);
            Assert.Equal(new[] { "Машина едет со скоростью 100 км/ч." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText011()
        {
            var result = Segmenter.Segment("Я поем и/или лягу спать.", Language.Russian);
            Assert.Equal(new[] { "Я поем и/или лягу спать." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText012()
        {
            var result = Segmenter.Segment("Он не мог справиться с примером \"3 + (14:7) = 5\"", Language.Russian);
            Assert.Equal(new[] { "Он не мог справиться с примером \"3 + (14:7) = 5\"" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText013()
        {
            var result = Segmenter.Segment("Вот список: 1.мороженое, 2.мясо, 3.рис.", Language.Russian);
            Assert.Equal(new[] { "Вот список: 1.мороженое, 2.мясо, 3.рис." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText014()
        {
            var result = Segmenter.Segment("Квартира 234 находится на 4-ом этаже.", Language.Russian);
            Assert.Equal(new[] { "Квартира 234 находится на 4-ом этаже." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText015()
        {
            var result = Segmenter.Segment("В это время года температура может подниматься до 40°C.", Language.Russian);
            Assert.Equal(new[] { "В это время года температура может подниматься до 40°C." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText016()
        {
            var result = Segmenter.Segment("Объем составляет 5м³.", Language.Russian);
            Assert.Equal(new[] { "Объем составляет 5м³." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText017()
        {
            var result = Segmenter.Segment("Объем составляет 5 куб.м.", Language.Russian);
            Assert.Equal(new[] { "Объем составляет 5 куб.м." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText018()
        {
            var result = Segmenter.Segment("Площадь комнаты 14м².", Language.Russian);
            Assert.Equal(new[] { "Площадь комнаты 14м²." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText019()
        {
            var result = Segmenter.Segment("Площадь комнаты 14 кв.м.", Language.Russian);
            Assert.Equal(new[] { "Площадь комнаты 14 кв.м." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText020()
        {
            var result = Segmenter.Segment("1°C соответствует 33.8°F.", Language.Russian);
            Assert.Equal(new[] { "1°C соответствует 33.8°F." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText021()
        {
            var result = Segmenter.Segment("Сегодня 27.10.14", Language.Russian);
            Assert.Equal(new[] { "Сегодня 27.10.14" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText022()
        {
            var result = Segmenter.Segment("Сегодня 27 октября 2014 года.", Language.Russian);
            Assert.Equal(new[] { "Сегодня 27 октября 2014 года." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText023()
        {
            var result = Segmenter.Segment("Эта машина стоит 150 000 дол.!", Language.Russian);
            Assert.Equal(new[] { "Эта машина стоит 150 000 дол.!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText024()
        {
            var result = Segmenter.Segment("Эта машина стоит $150 000!", Language.Russian);
            Assert.Equal(new[] { "Эта машина стоит $150 000!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText025()
        {
            var result = Segmenter.Segment("Вот номер моего телефона: +39045969798. Передавайте привет г-ну Шапочкину. До свидания.", Language.Russian);
            Assert.Equal(new[] { "Вот номер моего телефона: +39045969798.", "Передавайте привет г-ну Шапочкину.", "До свидания." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText026()
        {
            var result = Segmenter.Segment("Постойте, разве можно указывать цены в у.е.!", Language.Russian);
            Assert.Equal(new[] { "Постойте, разве можно указывать цены в у.е.!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText027()
        {
            var result = Segmenter.Segment("Едем на скорости 90 км/ч в сторону пгт. Брагиновка, о котором мы так много слышали по ТВ!", Language.Russian);
            Assert.Equal(new[] { "Едем на скорости 90 км/ч в сторону пгт. Брагиновка, о котором мы так много слышали по ТВ!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText028()
        {
            var result = Segmenter.Segment("Д-р ветеринарных наук А. И. Семенов и пр. выступали на этом семинаре.", Language.Russian);
            Assert.Equal(new[] { "Д-р ветеринарных наук А. И. Семенов и пр. выступали на этом семинаре." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText029()
        {
            var result = Segmenter.Segment("Уважаемый проф. Семенов! Просьба до 20.10 сдать отчет на кафедру.", Language.Russian);
            Assert.Equal(new[] { "Уважаемый проф. Семенов!", "Просьба до 20.10 сдать отчет на кафедру." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText030()
        {
            var result = Segmenter.Segment("Первоначальная стоимость этого комплекта 30 долл., но сейчас действует скидка. Предъявите дисконтную карту, пожалуйста!", Language.Russian);
            Assert.Equal(new[] { "Первоначальная стоимость этого комплекта 30 долл., но сейчас действует скидка.", "Предъявите дисконтную карту, пожалуйста!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText031()
        {
            var result = Segmenter.Segment("Виктор съел пол-лимона и ушел по-английски из дома на ул. 1 Мая.", Language.Russian);
            Assert.Equal(new[] { "Виктор съел пол-лимона и ушел по-английски из дома на ул. 1 Мая." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText032()
        {
            var result = Segmenter.Segment("Напоминаю Вам, что 25.10 день рождения у Маши К., нужно будет купить ей подарок.", Language.Russian);
            Assert.Equal(new[] { "Напоминаю Вам, что 25.10 день рождения у Маши К., нужно будет купить ей подарок." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText033()
        {
            var result = Segmenter.Segment("В 2010-2012 гг. Виктор посещал г. Волгоград неоднократно.", Language.Russian);
            Assert.Equal(new[] { "В 2010-2012 гг. Виктор посещал г. Волгоград неоднократно." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText034()
        {
            var result = Segmenter.Segment("Маленькая девочка бежала и кричала: «Не видали маму?»", Language.Russian);
            Assert.Equal(new[] { "Маленькая девочка бежала и кричала: «Не видали маму?»" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText035()
        {
            var result = Segmenter.Segment("Кв. 234 находится на 4 этаже.", Language.Russian);
            Assert.Equal(new[] { "Кв. 234 находится на 4 этаже." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText036()
        {
            var result = Segmenter.Segment("В это время года температура может подниматься до 40°C.", Language.Russian);
            Assert.Equal(new[] { "В это время года температура может подниматься до 40°C." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText037()
        {
            var result = Segmenter.Segment("Нужно купить 1)рыбу 2)соль.", Language.Russian);
            Assert.Equal(new[] { "Нужно купить 1)рыбу 2)соль." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText038()
        {
            var result = Segmenter.Segment("Машина едет со скоростью 100 км/ч.", Language.Russian);
            Assert.Equal(new[] { "Машина едет со скоростью 100 км/ч." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText039()
        {
            var result = Segmenter.Segment("Л.Н. Толстой написал \"Войну и мир\". Кроме Волконских, Л. Н. Толстой состоял в близком родстве с некоторыми другими аристократическими родами. Дом, где родился Л.Н.Толстой, 1898 г. В 1854 году дом продан по распоряжению писателя на вывоз в село Долгое.", Language.Russian);
            Assert.Equal(new[] { "Л.Н. Толстой написал \"Войну и мир\".", "Кроме Волконских, Л. Н. Толстой состоял в близком родстве с некоторыми другими аристократическими родами.", "Дом, где родился Л.Н.Толстой, 1898 г. В 1854 году дом продан по распоряжению писателя на вывоз в село Долгое." }, result);
        }
    }
}