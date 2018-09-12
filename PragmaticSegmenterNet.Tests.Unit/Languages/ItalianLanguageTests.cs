namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class ItalianLanguageTests
    {
        [Fact]
        public void Abbreviations001()
        {
            var result = Segmenter.Segment("Salve Sig.ra Mengoni! Come sta oggi?", Language.Italian);
            Assert.Equal(new[] { "Salve Sig.ra Mengoni!", "Come sta oggi?" }, result);
        }

        [Fact]
        public void Quotations002()
        {
            var result = Segmenter.Segment("Una lettera si può iniziare in questo modo «Il/la sottoscritto/a.».", Language.Italian);
            Assert.Equal(new[] { "Una lettera si può iniziare in questo modo «Il/la sottoscritto/a.»." }, result);
        }

        [Fact]
        public void Numbers003()
        {
            var result = Segmenter.Segment("La casa costa 170.500.000,00€!", Language.Italian);
            Assert.Equal(new[] { "La casa costa 170.500.000,00€!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment("Salve Sig.ra Mengoni! Come sta oggi?", Language.Italian);
            Assert.Equal(new[] { "Salve Sig.ra Mengoni!", "Come sta oggi?" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText002()
        {
            var result = Segmenter.Segment("Buongiorno! Sono l'Ing. Mengozzi. È presente l'Avv. Cassioni?", Language.Italian);
            Assert.Equal(new[] { "Buongiorno!", "Sono l'Ing. Mengozzi.", "È presente l'Avv. Cassioni?" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText003()
        {
            var result = Segmenter.Segment("Mi fissi un appuntamento per mar. 23 Nov.. Grazie.", Language.Italian);
            Assert.Equal(new[] { "Mi fissi un appuntamento per mar. 23 Nov..", "Grazie." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText004()
        {
            var result = Segmenter.Segment("Ecco il mio tel.:01234567. Mi saluti la Sig.na Manelli. Arrivederci.", Language.Italian);
            Assert.Equal(new[] { "Ecco il mio tel.:01234567.", "Mi saluti la Sig.na Manelli.", "Arrivederci." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText005()
        {
            var result = Segmenter.Segment("La centrale meteor. si è guastata. Gli idraul. son dovuti andare a sistemarla.", Language.Italian);
            Assert.Equal(new[] { "La centrale meteor. si è guastata.", "Gli idraul. son dovuti andare a sistemarla." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText006()
        {
            var result = Segmenter.Segment("Hanno creato un algoritmo allo st. d. arte. Si ringrazia lo psicol. Serenti.", Language.Italian);
            Assert.Equal(new[] { "Hanno creato un algoritmo allo st. d. arte.", "Si ringrazia lo psicol. Serenti." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText007()
        {
            var result = Segmenter.Segment("Chiamate il V.Cte. delle F.P., adesso!", Language.Italian);
            Assert.Equal(new[] { "Chiamate il V.Cte. delle F.P., adesso!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText008()
        {
            var result = Segmenter.Segment("Giancarlo ha sostenuto l'esame di econ. az..", Language.Italian);
            Assert.Equal(new[] { "Giancarlo ha sostenuto l'esame di econ. az.." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText009()
        {
            var result = Segmenter.Segment("Stava viaggiando a 90 km/h verso la provincia di TR quando il Dott. Mesini ha sentito un rumore e si fermò!", Language.Italian);
            Assert.Equal(new[] { "Stava viaggiando a 90 km/h verso la provincia di TR quando il Dott. Mesini ha sentito un rumore e si fermò!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText010()
        {
            var result = Segmenter.Segment("Egregio Dir. Amm., le faccio sapere che l'ascensore non funziona.", Language.Italian);
            Assert.Equal(new[] { "Egregio Dir. Amm., le faccio sapere che l'ascensore non funziona." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText011()
        {
            var result = Segmenter.Segment("Stava mangiando e/o dormendo.", Language.Italian);
            Assert.Equal(new[] { "Stava mangiando e/o dormendo." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText012()
        {
            var result = Segmenter.Segment("Ricordatevi che dom 25 Set. sarà il compleanno di Maria; dovremo darle un regalo.", Language.Italian);
            Assert.Equal(new[] { "Ricordatevi che dom 25 Set. sarà il compleanno di Maria; dovremo darle un regalo." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText013()
        {
            var result = Segmenter.Segment("La politica è quella della austerità; quindi verranno fatti tagli agli sprechi.", Language.Italian);
            Assert.Equal(new[] { "La politica è quella della austerità; quindi verranno fatti tagli agli sprechi." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText014()
        {
            var result = Segmenter.Segment("Nel tribunale, l'Avv. Fabrizi ha urlato \"Io, l'illustrissimo Fabrizi, vi si oppone!\".", Language.Italian);
            Assert.Equal(new[] { "Nel tribunale, l'Avv. Fabrizi ha urlato \"Io, l'illustrissimo Fabrizi, vi si oppone!\"." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText015()
        {
            var result = Segmenter.Segment("Le parti fisiche di un computer (ad es. RAM, CPU, tastiera, mouse, etc.) sono definiti HW.", Language.Italian);
            Assert.Equal(new[] { "Le parti fisiche di un computer (ad es. RAM, CPU, tastiera, mouse, etc.) sono definiti HW." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText016()
        {
            var result = Segmenter.Segment("La parola 'casa' è sinonimo di abitazione.", Language.Italian);
            Assert.Equal(new[] { "La parola 'casa' è sinonimo di abitazione." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText017()
        {
            var result = Segmenter.Segment("La \"Mulino Bianco\" fa alimentari pre-confezionati.", Language.Italian);
            Assert.Equal(new[] { "La \"Mulino Bianco\" fa alimentari pre-confezionati." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText018()
        {
            var result = Segmenter.Segment("\"Ei fu. Siccome immobile / dato il mortal sospiro / stette la spoglia immemore / orba di tanto spiro / [...]\" (Manzoni).", Language.Italian);
            Assert.Equal(new[] { "\"Ei fu. Siccome immobile / dato il mortal sospiro / stette la spoglia immemore / orba di tanto spiro / [...]\" (Manzoni)." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText019()
        {
            var result = Segmenter.Segment("Una lettera si può iniziare in questo modo «Il/la sottoscritto/a ... nato/a a ...».", Language.Italian);
            Assert.Equal(new[] { "Una lettera si può iniziare in questo modo «Il/la sottoscritto/a ... nato/a a ...»." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText020()
        {
            var result = Segmenter.Segment("Per casa, in uno degli esercizi per i bambini c'era \"3 + (14/7) = 5\"", Language.Italian);
            Assert.Equal(new[] { "Per casa, in uno degli esercizi per i bambini c'era \"3 + (14/7) = 5\"" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText021()
        {
            var result = Segmenter.Segment("Ai bambini è stato chiesto di fare \"4:2*2\"", Language.Italian);
            Assert.Equal(new[] { "Ai bambini è stato chiesto di fare \"4:2*2\"" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText022()
        {
            var result = Segmenter.Segment("La maestra esclamò: \"Bambini, quanto fa '2/3 + 4/3?'\".", Language.Italian);
            Assert.Equal(new[] { "La maestra esclamò: \"Bambini, quanto fa \'2/3 + 4/3?\'\"." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText023()
        {
            var result = Segmenter.Segment("Il motore misurava 120°C.", Language.Italian);
            Assert.Equal(new[] { "Il motore misurava 120°C." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText024()
        {
            var result = Segmenter.Segment("Il volume era di 3m³.", Language.Italian);
            Assert.Equal(new[] { "Il volume era di 3m³." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText025()
        {
            var result = Segmenter.Segment("La stanza misurava 20m².", Language.Italian);
            Assert.Equal(new[] { "La stanza misurava 20m²." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText026()
        {
            var result = Segmenter.Segment("1°C corrisponde a 33.8°F.", Language.Italian);
            Assert.Equal(new[] { "1°C corrisponde a 33.8°F." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText027()
        {
            var result = Segmenter.Segment("Oggi è il 27-10-14.", Language.Italian);
            Assert.Equal(new[] { "Oggi è il 27-10-14." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText028()
        {
            var result = Segmenter.Segment("La casa costa 170.500.000,00€!", Language.Italian);
            Assert.Equal(new[] { "La casa costa 170.500.000,00€!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText029()
        {
            var result = Segmenter.Segment("Il corridore 103 è arrivato 4°.", Language.Italian);
            Assert.Equal(new[] { "Il corridore 103 è arrivato 4°." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText030()
        {
            var result = Segmenter.Segment("Oggi è il 27/10/2014.", Language.Italian);
            Assert.Equal(new[] { "Oggi è il 27/10/2014." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText031()
        {
            var result = Segmenter.Segment("Ecco l'elenco: 1.gelato, 2.carne, 3.riso.", Language.Italian);
            Assert.Equal(new[] { "Ecco l'elenco: 1.gelato, 2.carne, 3.riso." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText032()
        {
            var result = Segmenter.Segment("Devi comprare : 1)pesce 2)sale.", Language.Italian);
            Assert.Equal(new[] { "Devi comprare : 1)pesce 2)sale." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText033()
        {
            var result = Segmenter.Segment("La macchina viaggiava a 100 km/h.", Language.Italian);
            Assert.Equal(new[] { "La macchina viaggiava a 100 km/h." }, result);
        }
    }
}
