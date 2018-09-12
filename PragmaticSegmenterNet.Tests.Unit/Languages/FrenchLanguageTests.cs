namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class FrenchLanguageTests
    {
        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment("Après avoir été l'un des acteurs du projet génome humain, le Genoscope met aujourd'hui le cap vers la génomique environnementale. L'exploitation des données de séquences, prolongée par l'identification expérimentale des fonctions biologiques, notamment dans le domaine de la biocatalyse, ouvrent des perspectives de développements en biotechnologie industrielle.", Language.French);
            Assert.Equal(new[] { "Après avoir été l'un des acteurs du projet génome humain, le Genoscope met aujourd'hui le cap vers la génomique environnementale.", "L'exploitation des données de séquences, prolongée par l'identification expérimentale des fonctions biologiques, notamment dans le domaine de la biocatalyse, ouvrent des perspectives de développements en biotechnologie industrielle." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText002()
        {
            var result = Segmenter.Segment("\"Airbus livrera comme prévu 30 appareils 380 cette année avec en ligne de mire l'objectif d'équilibre financier du programme en 2015\", a-t-il ajouté.", Language.French);
            Assert.Equal(new[] { "\"Airbus livrera comme prévu 30 appareils 380 cette année avec en ligne de mire l'objectif d'équilibre financier du programme en 2015\", a-t-il ajouté." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText003()
        {
            var result = Segmenter.Segment("À 11 heures ce matin, la direction ne décomptait que douze grévistes en tout sur la France : ce sont ceux du site de Saran (Loiret), dont l’effectif est de 809 salariés, dont la moitié d’intérimaires. Elle assure que ce mouvement « n’aura aucun impact sur les livraisons ».", Language.French);
            Assert.Equal(new[] { "À 11 heures ce matin, la direction ne décomptait que douze grévistes en tout sur la France : ce sont ceux du site de Saran (Loiret), dont l’effectif est de 809 salariés, dont la moitié d’intérimaires.", "Elle assure que ce mouvement « n’aura aucun impact sur les livraisons »." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText004()
        {
            var result = Segmenter.Segment("Ce modèle permet d’afficher le texte « LL.AA.II.RR. » pour l’abréviation de « Leurs Altesses impériales et royales » avec son infobulle.", Language.French);
            Assert.Equal(new[] { "Ce modèle permet d’afficher le texte « LL.AA.II.RR. » pour l’abréviation de « Leurs Altesses impériales et royales » avec son infobulle." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText005()
        {
            var result = Segmenter.Segment("Les derniers ouvrages de Intercept Ltd. sont ici.", Language.French);
            Assert.Equal(new[] { "Les derniers ouvrages de Intercept Ltd. sont ici." }, result);
        }


    }
}
