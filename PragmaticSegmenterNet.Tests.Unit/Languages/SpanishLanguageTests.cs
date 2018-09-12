namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class SpanishLanguageTests
    {
        [Fact]
        public void QuestionMarkToEndSentence001()
        {
            var result = Segmenter.Segment("¿Cómo está hoy? Espero que muy bien.", Language.Spanish);
            Assert.Equal(new[] { "¿Cómo está hoy?", "Espero que muy bien." }, result);
        }

        [Fact]
        public void ExclamationPointToEndSentence002()
        {
            var result = Segmenter.Segment("¡Hola señorita! Espero que muy bien.", Language.Spanish);
            Assert.Equal(new[] { "¡Hola señorita!", "Espero que muy bien." }, result);
        }

        [Fact]
        public void Abbreviations003()
        {
            var result = Segmenter.Segment("Hola Srta. Ledesma. Buenos días, soy el Lic. Naser Pastoriza, y él es mi padre, el Dr. Naser.", Language.Spanish);
            Assert.Equal(new[] { "Hola Srta. Ledesma.", "Buenos días, soy el Lic. Naser Pastoriza, y él es mi padre, el Dr. Naser." }, result);
        }

        [Fact]
        public void Numbers004()
        {
            var result = Segmenter.Segment("¡La casa cuesta $170.500.000,00! ¡Muy costosa! Se prevé una disminución del 12.5% para el próximo año.", Language.Spanish);
            Assert.Equal(new[] { "¡La casa cuesta $170.500.000,00!", "¡Muy costosa!", "Se prevé una disminución del 12.5% para el próximo año." }, result);
        }

        [Fact]
        public void Quotations005()
        {
            var result = Segmenter.Segment("«Ninguna mente extraordinaria está exenta de un toque de demencia.», dijo Aristóteles.", Language.Spanish);
            Assert.Equal(new[] { "«Ninguna mente extraordinaria está exenta de un toque de demencia.», dijo Aristóteles." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment("«Ninguna mente extraordinaria está exenta de un toque de demencia», dijo Aristóteles. Pablo, ¿adónde vas? ¡¿Qué viste?!", Language.Spanish);
            Assert.Equal(new[] { "«Ninguna mente extraordinaria está exenta de un toque de demencia», dijo Aristóteles.", "Pablo, ¿adónde vas?", "¡¿Qué viste?!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText002()
        {
            var result = Segmenter.Segment("Admón. es administración o me equivoco.", Language.Spanish);
            Assert.Equal(new[] { "Admón. es administración o me equivoco." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText003()
        {
            var result = Segmenter.Segment("• 1. Busca atención prenatal desde el principio \n• 2. Aliméntate bien \n• 3. Presta mucha atención a la higiene de los alimentos \n• 4. Toma suplementos de ácido fólico y come pescado \n• 5. Haz ejercicio regularmente \n• 6. Comienza a hacer ejercicios de Kegel \n• 7. Restringe el consumo de alcohol \n• 8. Disminuye el consumo de cafeína \n• 9. Deja de fumar \n• 10. Descansa", Language.Spanish);
            Assert.Equal(new[] { "• 1. Busca atención prenatal desde el principio", "• 2. Aliméntate bien", "• 3. Presta mucha atención a la higiene de los alimentos", "• 4. Toma suplementos de ácido fólico y come pescado", "• 5. Haz ejercicio regularmente", "• 6. Comienza a hacer ejercicios de Kegel", "• 7. Restringe el consumo de alcohol", "• 8. Disminuye el consumo de cafeína", "• 9. Deja de fumar", "• 10. Descansa" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText004()
        {
            var result = Segmenter.Segment("• 1. Busca atención prenatal desde el principio \n• 2. Aliméntate bien \n• 3. Presta mucha atención a la higiene de los alimentos \n• 4. Toma suplementos de ácido fólico y come pescado \n• 5. Haz ejercicio regularmente \n• 6. Comienza a hacer ejercicios de Kegel \n• 7. Restringe el consumo de alcohol \n• 8. Disminuye el consumo de cafeína \n• 9. Deja de fumar \n• 10. Descansa \n• 11. Hola", Language.Spanish);
            Assert.Equal(new[] { "• 1. Busca atención prenatal desde el principio", "• 2. Aliméntate bien", "• 3. Presta mucha atención a la higiene de los alimentos", "• 4. Toma suplementos de ácido fólico y come pescado", "• 5. Haz ejercicio regularmente", "• 6. Comienza a hacer ejercicios de Kegel", "• 7. Restringe el consumo de alcohol", "• 8. Disminuye el consumo de cafeína", "• 9. Deja de fumar", "• 10. Descansa", "• 11. Hola" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText005()
        {
            var result = Segmenter.Segment("¡Hola Srta. Ledesma! ¿Cómo está hoy? Espero que muy bien.", Language.Spanish);
            Assert.Equal(new[] { "¡Hola Srta. Ledesma!", "¿Cómo está hoy?", "Espero que muy bien." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText006()
        {
            var result = Segmenter.Segment("Buenos días, soy el Lic. Naser Pastoriza, y él es mi padre, el Dr. Naser.", Language.Spanish);
            Assert.Equal(new[] { "Buenos días, soy el Lic. Naser Pastoriza, y él es mi padre, el Dr. Naser." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText007()
        {
            var result = Segmenter.Segment("He apuntado una cita para la siguiente fecha: Mar. 23 de Nov. de 2014. Gracias.", Language.Spanish);
            Assert.Equal(new[] { "He apuntado una cita para la siguiente fecha: Mar. 23 de Nov. de 2014.", "Gracias." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText008()
        {
            var result = Segmenter.Segment("Núm. de tel: 351.123.465.4. Envíe mis saludos a la Sra. Rescia.", Language.Spanish);
            Assert.Equal(new[] { "Núm. de tel: 351.123.465.4.", "Envíe mis saludos a la Sra. Rescia." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText009()
        {
            var result = Segmenter.Segment(
                "Cero en la escala Celsius o de grados centígrados (0 °C) se define como el equivalente a 273.15 K, con una diferencia de temperatura de 1 °C equivalente a una diferencia de 1 Kelvin. Esto significa que 100 °C, definido como el punto de ebullición del agua, se define como el equivalente a 373.15 K.");
     
            Assert.Equal(new[] { "Cero en la escala Celsius o de grados centígrados (0 °C) se define como el equivalente a 273.15 K, con una diferencia de temperatura de 1 °C equivalente a una diferencia de 1 Kelvin.", "Esto significa que 100 °C, definido como el punto de ebullición del agua, se define como el equivalente a 373.15 K." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText010()
        {
            var result = Segmenter.Segment("Durante la primera misión del Discovery (30 Ago. 1984 15:08.10) tuvo lugar el lanzamiento de dos satélites de comunicación, el nombre de esta misión fue STS-41-D.", Language.Spanish);
            Assert.Equal(new[] { "Durante la primera misión del Discovery (30 Ago. 1984 15:08.10) tuvo lugar el lanzamiento de dos satélites de comunicación, el nombre de esta misión fue STS-41-D." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText011()
        {
            var result = Segmenter.Segment("Frase del gran José Hernández: \"Aquí me pongo a cantar / al compás de la vigüela, / que el hombre que lo desvela / una pena estrordinaria, / como la ave solitaria / con el cantar se consuela. / [...] \".", Language.Spanish);
            Assert.Equal(new[] { "Frase del gran José Hernández: \"Aquí me pongo a cantar / al compás de la vigüela, / que el hombre que lo desvela / una pena estrordinaria, / como la ave solitaria / con el cantar se consuela. / [...] \"."}, result);
        }

        [Fact]
        public void CorrectlySegmentsText012()
        {
            var result = Segmenter.Segment("Citando a Criss Jami «Prefiero ser un artista a ser un líder, irónicamente, un líder tiene que seguir las reglas.», lo cual parece muy acertado.", Language.Spanish);
            Assert.Equal(new[] { "Citando a Criss Jami «Prefiero ser un artista a ser un líder, irónicamente, un líder tiene que seguir las reglas.», lo cual parece muy acertado." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText013()
        {
            var result = Segmenter.Segment("Cuando llegué, le estaba dando ejercicios a los niños, uno de los cuales era \"3 + (14/7).x = 5\". ¿Qué te parece?", Language.Spanish);
            Assert.Equal(new[] { "Cuando llegué, le estaba dando ejercicios a los niños, uno de los cuales era \"3 + (14/7).x = 5\".", "¿Qué te parece?" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText014()
        {
            var result = Segmenter.Segment("Se le pidió a los niños que leyeran los párrf. 5 y 6 del art. 4 de la constitución de los EE. UU..", Language.Spanish);
            Assert.Equal(new[] { "Se le pidió a los niños que leyeran los párrf. 5 y 6 del art. 4 de la constitución de los EE. UU.." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText015()
        {
            var result = Segmenter.Segment("Una de las preguntas realizadas en la evaluación del día Lun. 15 de Mar. fue la siguiente: \"Alumnos, ¿cuál es el resultado de la operación 1.1 + 4/5?\". Disponían de 1 min. para responder esa pregunta.", Language.Spanish);
            Assert.Equal(new[] { "Una de las preguntas realizadas en la evaluación del día Lun. 15 de Mar. fue la siguiente: \"Alumnos, ¿cuál es el resultado de la operación 1.1 + 4/5?\".", "Disponían de 1 min. para responder esa pregunta." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText016()
        {
            var result = Segmenter.Segment("La temperatura del motor alcanzó los 120.5°C. Afortunadamente, pudo llegar al final de carrera.", Language.Spanish);
            Assert.Equal(new[] { "La temperatura del motor alcanzó los 120.5°C.", "Afortunadamente, pudo llegar al final de carrera." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText017()
        {
            var result = Segmenter.Segment("El volumen del cuerpo es 3m³. ¿Cuál es la superficie de cada cara del prisma?", Language.Spanish);
            Assert.Equal(new[] { "El volumen del cuerpo es 3m³.", "¿Cuál es la superficie de cada cara del prisma?" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText018()
        {
            var result = Segmenter.Segment("La habitación tiene 20.55m². El living tiene 50.0m².", Language.Spanish);
            Assert.Equal(new[] { "La habitación tiene 20.55m².", "El living tiene 50.0m²." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText019()
        {
            var result = Segmenter.Segment("1°C corresponde a 33.8°F. ¿A cuánto corresponde 35°C?", Language.Spanish);
            Assert.Equal(new[] { "1°C corresponde a 33.8°F.", "¿A cuánto corresponde 35°C?" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText020()
        {
            var result = Segmenter.Segment("Hamilton ganó el último gran premio de Fórmula 1, luego de 1:39:02.619 Hs. de carrera, segundo resultó Massa, a una diferencia de 2.5 segundos. De esta manera se consagró ¡Campeón mundial!", Language.Spanish);
            Assert.Equal(new[] { "Hamilton ganó el último gran premio de Fórmula 1, luego de 1:39:02.619 Hs. de carrera, segundo resultó Massa, a una diferencia de 2.5 segundos.", "De esta manera se consagró ¡Campeón mundial!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText021()
        {
            var result = Segmenter.Segment("¡La casa cuesta $170.500.000,00! ¡Muy costosa! Se prevé una disminución del 12.5% para el próximo año.", Language.Spanish);
            Assert.Equal(new[] { "¡La casa cuesta $170.500.000,00!", "¡Muy costosa!", "Se prevé una disminución del 12.5% para el próximo año." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText022()
        {
            var result = Segmenter.Segment("El corredor No. 103 arrivó 4°.", Language.Spanish);
            Assert.Equal(new[] { "El corredor No. 103 arrivó 4°." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText023()
        {
            var result = Segmenter.Segment("Hoy es 27/04/2014, y es mi cumpleaños. ¿Cuándo es el tuyo?", Language.Spanish);
            Assert.Equal(new[] { "Hoy es 27/04/2014, y es mi cumpleaños.", "¿Cuándo es el tuyo?" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText024()
        {
            var result = Segmenter.Segment("Aquí está la lista de compras para el almuerzo: 1.Helado, 2.Carne, 3.Arroz. ¿Cuánto costará? Quizás $12.5.", Language.Spanish);
            Assert.Equal(new[] { "Aquí está la lista de compras para el almuerzo: 1.Helado, 2.Carne, 3.Arroz.", "¿Cuánto costará?", "Quizás $12.5." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText025()
        {
            var result = Segmenter.Segment("1 + 1 es 2. 2 + 2 es 4. El auto es de color rojo.", Language.Spanish);
            Assert.Equal(new[] { "1 + 1 es 2.", "2 + 2 es 4.", "El auto es de color rojo." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText026()
        {
            var result = Segmenter.Segment("La máquina viajaba a 100 km/h. ¿En cuánto tiempo recorrió los 153 Km.?", Language.Spanish);
            Assert.Equal(new[] { "La máquina viajaba a 100 km/h.", "¿En cuánto tiempo recorrió los 153 Km.?" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText027()
        {
            var result = Segmenter.Segment(
                "\n \nCentro de Relaciones Interinstitucionales -CERI \n\nCra. 7 No. 40-53 Piso 10 Tel.  (57-1) 3239300 Ext. 1010 Fax: (57-1) 3402973 Bogotá, D.C. - Colombia \n\nhttp://www.udistrital.edu.co - http://ceri.udistrital.edu.co - relinter@udistrital.edu.co \n\n \n\nCERI 0908 \n \nBogotá, D.C. 6 de noviembre de 2014.  \n \nSeñores: \nEMBAJADA DE UNITED KINGDOM \n \n", Language.Spanish);
            Assert.Equal(new[] { "Centro de Relaciones Interinstitucionales -CERI", "Cra. 7 No. 40-53 Piso 10 Tel.  (57-1) 3239300 Ext. 1010 Fax: (57-1) 3402973 Bogotá, D.C. - Colombia", "http://www.udistrital.edu.co - http://ceri.udistrital.edu.co - relinter@udistrital.edu.co", "CERI 0908", "Bogotá, D.C. 6 de noviembre de 2014.", "Señores:", "EMBAJADA DE UNITED KINGDOM" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText028()
        {
            var result = Segmenter.Segment("N°. 1026.253.553", Language.Spanish);
            Assert.Equal(new[] { "N°. 1026.253.553" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText029()
        {
            var result = Segmenter.Segment("\nA continuación me permito presentar a la Ingeniera LAURA MILENA LEÓN \nSANDOVAL, identificada con el documento N°. 1026.253.553 de Bogotá, \negresada del Programa Ingeniería Industrial en el año 2012, quien se desatacó por \nsu excelencia académica, actualmente cursa el programa de Maestría en \nIngeniería Industrial y se encuentra en un intercambio cultural en Bangalore – \nIndia.", Language.Spanish, documentType: DocumentType.Pdf);
            Assert.Equal(new[] { "A continuación me permito presentar a la Ingeniera LAURA MILENA LEÓN SANDOVAL, identificada con el documento N°. 1026.253.553 de Bogotá, egresada del Programa Ingeniería Industrial en el año 2012, quien se desatacó por su excelencia académica, actualmente cursa el programa de Maestría en Ingeniería Industrial y se encuentra en un intercambio cultural en Bangalore – India." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText030()
        {
            var result = Segmenter.Segment("\n__________________________________________________________\nEl Board para Servicios Educativos de Putnam/Northern Westchester según el título IX, Sección 504 del “Rehabilitation Act” del 1973, del Título VII y del Acta “American with Disabilities” no discrimina para la admisión a programas educativos por sexo, creencia, nacionalidad, origen, edad o discapacidad.", Language.Spanish);
            Assert.Equal(new[] { "El Board para Servicios Educativos de Putnam/Northern Westchester según el título IX, Sección 504 del “Rehabilitation Act” del 1973, del Título VII y del Acta “American with Disabilities” no discrimina para la admisión a programas educativos por sexo, creencia, nacionalidad, origen, edad o discapacidad." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText031()
        {
            var result = Segmenter.Segment("Explora oportunidades de carrera en el área de Salud en el Hospital de Northern en Mt. Kisco.", Language.Spanish);
            Assert.Equal(new[] { "Explora oportunidades de carrera en el área de Salud en el Hospital de Northern en Mt. Kisco." }, result);
        }


    }
}