namespace PragmaticSegmenterNet.Tests.Unit.Languages
{
    using Xunit;

    public class GermanLanguageTests
    {
        [Fact]
        public void QuotationAtEndOfSentence001()
        {
            var result = Segmenter.Segment("„Ich habe heute keine Zeit“, sagte die Frau und flüsterte leise: „Und auch keine Lust.“ Wir haben 1.000.000 Euro.", Language.German);
            Assert.Equal(new[] { "„Ich habe heute keine Zeit“, sagte die Frau und flüsterte leise: „Und auch keine Lust.“", "Wir haben 1.000.000 Euro." }, result);
        }

        [Fact]
        public void Abbreviations002()
        {
            var result = Segmenter.Segment("Es gibt jedoch einige Vorsichtsmaßnahmen, die Du ergreifen kannst, z. B. ist es sehr empfehlenswert, dass Du Dein Zuhause von allem Junkfood befreist.", Language.German);
            Assert.Equal(new[] { "Es gibt jedoch einige Vorsichtsmaßnahmen, die Du ergreifen kannst, z. B. ist es sehr empfehlenswert, dass Du Dein Zuhause von allem Junkfood befreist." }, result);
        }

        [Fact]
        public void Numbers003()
        {
            var result = Segmenter.Segment("Was sind die Konsequenzen der Abstimmung vom 12. Juni?", Language.German);
            Assert.Equal(new[] { "Was sind die Konsequenzen der Abstimmung vom 12. Juni?" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText001()
        {
            var result = Segmenter.Segment(
                "\n   \n\n   http:www.babycentre.co.uk/midwives \n\n \n\n \n\n10 steps to a healthy pregnancy (German) \n\n10 Schritte zu einer gesunden Schwangerschaft \n \n• 1. Planen und organisieren Sie die Zeit der Schwangerschaft frühzeitig! \n• 2. Essen Sie gesund! \n• 3. Seien Sie achtsam bei der Auswahl der Nahrungsmittel! \n• 4. Nehmen Sie zusätzlich Folsäurepräparate und essen Sie Fisch! \n• 5. Treiben Sie regelmäßig Sport! \n• 6. Beginnen Sie mit Übungen für die Beckenbodenmuskulatur! \n• 7. Reduzieren Sie Ihren Alkoholgenuss! \n• 8. Reduzieren Sie Ihren Koffeingenuß! \n• 9. Hören Sie mit dem Rauchen auf! \n• 10. Gönnen Sie sich Erholung! \n \n \nZehn einfach zu befolgende Tipps sollen Ihnen helfen, eine möglichst problemlose \nSchwangerschaft zu erleben und ein gesundes Baby auf die Welt zu bringen:  \n\n1. Planen und organisieren Sie die Zeit der Schwangerschaft frühzeitig!",
                Language.German, documentType: DocumentType.Pdf);
      
            Assert.Equal(new[] { "http:www.babycentre.co.uk/midwives", "10 steps to a healthy pregnancy (German)", "10 Schritte zu einer gesunden Schwangerschaft", "• 1. Planen und organisieren Sie die Zeit der Schwangerschaft frühzeitig!", "• 2. Essen Sie gesund!", "• 3. Seien Sie achtsam bei der Auswahl der Nahrungsmittel!", "• 4. Nehmen Sie zusätzlich Folsäurepräparate und essen Sie Fisch!", "• 5. Treiben Sie regelmäßig Sport!", "• 6. Beginnen Sie mit Übungen für die Beckenbodenmuskulatur!", "• 7. Reduzieren Sie Ihren Alkoholgenuss!", "• 8. Reduzieren Sie Ihren Koffeingenuß!", "• 9. Hören Sie mit dem Rauchen auf!", "• 10. Gönnen Sie sich Erholung!", "Zehn einfach zu befolgende Tipps sollen Ihnen helfen, eine möglichst problemlose Schwangerschaft zu erleben und ein gesundes Baby auf die Welt zu bringen:", "1. Planen und organisieren Sie die Zeit der Schwangerschaft frühzeitig!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText002()
        {
            var result = Segmenter.Segment("„Ich habe heute keine Zeit“, sagte die Frau und flüsterte leise: „Und auch keine Lust.“ Wir haben 1.000.000 Euro.", Language.German);
            Assert.Equal(new[] { "„Ich habe heute keine Zeit“, sagte die Frau und flüsterte leise: „Und auch keine Lust.“", "Wir haben 1.000.000 Euro." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText003()
        {
            var result = Segmenter.Segment("Thomas sagte: ,,Wann kommst zu mir?” ,,Das weiß ich noch nicht“, antwortete Susi, ,,wahrscheinlich am Sonntag.“ Wir haben 1.000.000 Euro.", Language.German);
            Assert.Equal(new[] { "Thomas sagte: ,,Wann kommst zu mir?” ,,Das weiß ich noch nicht“, antwortete Susi, ,,wahrscheinlich am Sonntag.“", "Wir haben 1.000.000 Euro." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText004()
        {
            var result = Segmenter.Segment("„Lass uns jetzt essen gehen!“, sagte die Mutter zu ihrer Freundin, „am besten zum Italiener.“", Language.German);
            Assert.Equal(new[] { "„Lass uns jetzt essen gehen!“, sagte die Mutter zu ihrer Freundin, „am besten zum Italiener.“" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText005()
        {
            var result = Segmenter.Segment("Wir haben 1.000.000 Euro.", Language.German);
            Assert.Equal(new[] { "Wir haben 1.000.000 Euro." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText006()
        {
            var result = Segmenter.Segment("Sie bekommen 3,50 Euro zurück.", Language.German);
            Assert.Equal(new[] { "Sie bekommen 3,50 Euro zurück." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText007()
        {
            var result = Segmenter.Segment("Dafür brauchen wir 5,5 Stunden.", Language.German);
            Assert.Equal(new[] { "Dafür brauchen wir 5,5 Stunden." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText008()
        {
            var result = Segmenter.Segment("Bitte überweisen Sie 5.300,25 Euro.", Language.German);
            Assert.Equal(new[] { "Bitte überweisen Sie 5.300,25 Euro." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText009()
        {
            var result = Segmenter.Segment("1. Dies ist eine Punkteliste.", Language.German);
            Assert.Equal(new[] { "1. Dies ist eine Punkteliste." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText010()
        {
            var result = Segmenter.Segment("Wir trafen Dr. med. Meyer in der Stadt.", Language.German);
            Assert.Equal(new[] { "Wir trafen Dr. med. Meyer in der Stadt." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText011()
        {
            var result = Segmenter.Segment("Wir brauchen Getränke, z. B. Wasser, Saft, Bier usw.", Language.German);
            Assert.Equal(new[] { "Wir brauchen Getränke, z. B. Wasser, Saft, Bier usw." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText012()
        {
            var result = Segmenter.Segment("Ich kann u.a. Spanisch sprechen.", Language.German);
            Assert.Equal(new[] { "Ich kann u.a. Spanisch sprechen." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText013()
        {
            var result = Segmenter.Segment("Frau Prof. Schulze ist z. Z. nicht da.", Language.German);
            Assert.Equal(new[] { "Frau Prof. Schulze ist z. Z. nicht da." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText014()
        {
            var result = Segmenter.Segment("Sie erhalten ein neues Bank-Statement bzw. ein neues Schreiben.", Language.German);
            Assert.Equal(new[] { "Sie erhalten ein neues Bank-Statement bzw. ein neues Schreiben." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText015()
        {
            var result = Segmenter.Segment("Z. T. ist die Lieferung unvollständig.", Language.German);
            Assert.Equal(new[] { "Z. T. ist die Lieferung unvollständig." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText016()
        {
            var result = Segmenter.Segment("Das finden Sie auf S. 225.", Language.German);
            Assert.Equal(new[] { "Das finden Sie auf S. 225." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText017()
        {
            var result = Segmenter.Segment("Sie besucht eine kath. Schule.", Language.German);
            Assert.Equal(new[] { "Sie besucht eine kath. Schule." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText018()
        {
            var result = Segmenter.Segment("Wir benötigen Zeitungen, Zeitschriften u. Ä. für unser Projekt.", Language.German);
            Assert.Equal(new[] { "Wir benötigen Zeitungen, Zeitschriften u. Ä. für unser Projekt." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText019()
        {
            var result = Segmenter.Segment("Das steht auf S. 23, s. vorherige Anmerkung.", Language.German);
            Assert.Equal(new[] { "Das steht auf S. 23, s. vorherige Anmerkung." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText020()
        {
            var result = Segmenter.Segment("Dies ist meine Adresse: Dr. Meier, Berliner Str. 5, 21234 Bremen.", Language.German);
            Assert.Equal(new[] { "Dies ist meine Adresse: Dr. Meier, Berliner Str. 5, 21234 Bremen." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText021()
        {
            var result = Segmenter.Segment("Er sagte: „Hallo, wie geht´s Ihnen, Frau Prof. Müller?“", Language.German);
            Assert.Equal(new[] { "Er sagte: „Hallo, wie geht´s Ihnen, Frau Prof. Müller?“" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText022()
        {
            var result = Segmenter.Segment("Fit in vier Wochen\n\nDeine Anleitung für eine reine Ernährung und ein gesünderes und glücklicheres Leben\n\nRECHTLICHE HINWEISE\n\nOhne die ausdrückliche schriftliche Genehmigung der Eigentümerin von instafemmefitness, Anna Anderson, darf dieses E-Book weder teilweise noch in vollem Umfang reproduziert, gespeichert, kopiert oder auf irgendeine Weise übertragen werden. Wenn Du das E-Book auf einem öffentlich zugänglichen Computer ausdruckst, musst Du es nach dem Ausdrucken von dem Computer löschen. Jedes E-Book wird mit einem Benutzernamen und Transaktionsinformationen versehen.\n\nVerstöße gegen dieses Urheberrecht werden im vollen gesetzlichen Umfang geltend gemacht. Obgleich die Autorin und Herausgeberin alle Anstrengungen unternommen hat, sicherzustellen, dass die Informationen in diesem Buch zum Zeitpunkt der Drucklegung korrekt sind, übernimmt die Autorin und Herausgeberin keine Haftung für etwaige Verluste, Schäden oder Störungen, die durch Fehler oder Auslassungen in Folge von Fahrlässigkeit, zufälligen Umständen oder sonstigen Ursachen entstehen, und lehnt hiermit jedwede solche Haftung ab.\n\nDieses Buch ist kein Ersatz für die medizinische Beratung durch Ärzte. Der Leser/die Leserin sollte regelmäßig einen Arzt/eine Ärztin hinsichtlich Fragen zu seiner/ihrer Gesundheit und vor allem in Bezug auf Symptome, die eventuell einer ärztlichen Diagnose oder Behandlung bedürfen, konsultieren.\n\nDie Informationen in diesem Buch sind dazu gedacht, ein ordnungsgemäßes Training zu ergänzen, nicht aber zu ersetzen. Wie jeder andere Sport, der Geschwindigkeit, Ausrüstung, Gleichgewicht und Umweltfaktoren einbezieht, stellt dieser Sport ein gewisses Risiko dar. Die Autorin und Herausgeberin rät den Lesern dazu, die volle Verantwortung für die eigene Sicherheit zu übernehmen und die eigenen Grenzen zu beachten. Vor dem Ausüben der in diesem Buch beschriebenen Übungen solltest Du sicherstellen, dass Deine Ausrüstung in gutem Zustand ist, und Du solltest keine Risiken außerhalb Deines Erfahrungs- oder Trainingsniveaus, Deiner Fähigkeiten oder Deines Komfortbereichs eingehen.\nHintergrundillustrationen Urheberrecht © 2013 bei Shuttershock, Buchgestaltung und -produktion durch Anna Anderson Verfasst von Anna Anderson\nUrheberrecht © 2014 Instafemmefitness. Alle Rechte vorbehalten\n\nÜber mich", Language.German);
            Assert.Equal(new[] { "Fit in vier Wochen", "Deine Anleitung für eine reine Ernährung und ein gesünderes und glücklicheres Leben", "RECHTLICHE HINWEISE", "Ohne die ausdrückliche schriftliche Genehmigung der Eigentümerin von instafemmefitness, Anna Anderson, darf dieses E-Book weder teilweise noch in vollem Umfang reproduziert, gespeichert, kopiert oder auf irgendeine Weise übertragen werden.", "Wenn Du das E-Book auf einem öffentlich zugänglichen Computer ausdruckst, musst Du es nach dem Ausdrucken von dem Computer löschen.", "Jedes E-Book wird mit einem Benutzernamen und Transaktionsinformationen versehen.", "Verstöße gegen dieses Urheberrecht werden im vollen gesetzlichen Umfang geltend gemacht.", "Obgleich die Autorin und Herausgeberin alle Anstrengungen unternommen hat, sicherzustellen, dass die Informationen in diesem Buch zum Zeitpunkt der Drucklegung korrekt sind, übernimmt die Autorin und Herausgeberin keine Haftung für etwaige Verluste, Schäden oder Störungen, die durch Fehler oder Auslassungen in Folge von Fahrlässigkeit, zufälligen Umständen oder sonstigen Ursachen entstehen, und lehnt hiermit jedwede solche Haftung ab.", "Dieses Buch ist kein Ersatz für die medizinische Beratung durch Ärzte.", "Der Leser/die Leserin sollte regelmäßig einen Arzt/eine Ärztin hinsichtlich Fragen zu seiner/ihrer Gesundheit und vor allem in Bezug auf Symptome, die eventuell einer ärztlichen Diagnose oder Behandlung bedürfen, konsultieren.", "Die Informationen in diesem Buch sind dazu gedacht, ein ordnungsgemäßes Training zu ergänzen, nicht aber zu ersetzen.", "Wie jeder andere Sport, der Geschwindigkeit, Ausrüstung, Gleichgewicht und Umweltfaktoren einbezieht, stellt dieser Sport ein gewisses Risiko dar.", "Die Autorin und Herausgeberin rät den Lesern dazu, die volle Verantwortung für die eigene Sicherheit zu übernehmen und die eigenen Grenzen zu beachten.", "Vor dem Ausüben der in diesem Buch beschriebenen Übungen solltest Du sicherstellen, dass Deine Ausrüstung in gutem Zustand ist, und Du solltest keine Risiken außerhalb Deines Erfahrungs- oder Trainingsniveaus, Deiner Fähigkeiten oder Deines Komfortbereichs eingehen.", "Hintergrundillustrationen Urheberrecht © 2013 bei Shuttershock, Buchgestaltung und -produktion durch Anna Anderson Verfasst von Anna Anderson", "Urheberrecht © 2014 Instafemmefitness.", "Alle Rechte vorbehalten", "Über mich" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText023()
        {
            var result = Segmenter.Segment(
                "Es gibt jedoch einige Vorsichtsmaßnahmen, die Du ergreifen kannst, z. B. ist es sehr empfehlenswert, dass Du Dein Zuhause von allem Junkfood befreist. Ich persönlich kaufe kein Junkfood oder etwas, das nicht rein ist (ich traue mir da selbst nicht!). Ich finde jeden Vorwand, um das Junkfood zu essen, vor allem die Vorstellung, dass ich nicht mehr in Versuchung kommen werde, wenn ich es jetzt aufesse und es weg ist. Es ist schon komisch, was unser Verstand mitunter anstellt!",
                Language.German);
      
            Assert.Equal(new[] { "Es gibt jedoch einige Vorsichtsmaßnahmen, die Du ergreifen kannst, z. B. ist es sehr empfehlenswert, dass Du Dein Zuhause von allem Junkfood befreist.", "Ich persönlich kaufe kein Junkfood oder etwas, das nicht rein ist (ich traue mir da selbst nicht!).", "Ich finde jeden Vorwand, um das Junkfood zu essen, vor allem die Vorstellung, dass ich nicht mehr in Versuchung kommen werde, wenn ich es jetzt aufesse und es weg ist.", "Es ist schon komisch, was unser Verstand mitunter anstellt!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText024()
        {
            var result = Segmenter.Segment("Ob Sie in Hannover nur auf der Durchreise, für einen längeren Aufenthalt oder zum Besuch einer der zahlreichen Messen sind: Die Hauptstadt des Landes Niedersachsens hat viele Sehenswürdigkeiten und ist zu jeder Jahreszeit eine Reise Wert. \nHannovers Ursprünge können bis zur römischen Kaiserzeit zurückverfolgt werden, und zwar durch Ausgrabungen von Tongefäßen aus dem 1. -3. Jahrhundert nach Christus, die an mehreren Stellen im Untergrund des Stadtzentrums durchgeführt wurden.", Language.German);
            Assert.Equal(new[] { "Ob Sie in Hannover nur auf der Durchreise, für einen längeren Aufenthalt oder zum Besuch einer der zahlreichen Messen sind: Die Hauptstadt des Landes Niedersachsens hat viele Sehenswürdigkeiten und ist zu jeder Jahreszeit eine Reise Wert.", "Hannovers Ursprünge können bis zur römischen Kaiserzeit zurückverfolgt werden, und zwar durch Ausgrabungen von Tongefäßen aus dem 1. -3. Jahrhundert nach Christus, die an mehreren Stellen im Untergrund des Stadtzentrums durchgeführt wurden." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText025()
        {
            var result = Segmenter.Segment("• 3. Seien Sie achtsam bei der Auswahl der Nahrungsmittel! \n• 4. Nehmen Sie zusätzlich Folsäurepräparate und essen Sie Fisch! \n• 5. Treiben Sie regelmäßig Sport! \n• 6. Beginnen Sie mit Übungen für die Beckenbodenmuskulatur! \n• 7. Reduzieren Sie Ihren Alkoholgenuss! \n", Language.German);
            Assert.Equal(new[] { "• 3. Seien Sie achtsam bei der Auswahl der Nahrungsmittel!", "• 4. Nehmen Sie zusätzlich Folsäurepräparate und essen Sie Fisch!", "• 5. Treiben Sie regelmäßig Sport!", "• 6. Beginnen Sie mit Übungen für die Beckenbodenmuskulatur!", "• 7. Reduzieren Sie Ihren Alkoholgenuss!" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText026()
        {
            var result = Segmenter.Segment("Schwangere Frauen sollten während der \nersten drei Monate eine tägliche Dosis von 400 Mikrogramm Folsäure zusätzlich nehmen. \nFolsäure befindet sich auch in einigen Gemüse- und Müslisorten.", Language.German);
            Assert.Equal(new[] { "Schwangere Frauen sollten während der ersten drei Monate eine tägliche Dosis von 400 Mikrogramm Folsäure zusätzlich nehmen.", "Folsäure befindet sich auch in einigen Gemüse- und Müslisorten." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText027()
        {
            var result = Segmenter.Segment("Andere \nFischsorten (z.B. Hai, Thunfisch, Aal und Seeteufel) weisen einen erhöhten Quecksilbergehalt \nauf und sollten deshalb in der Schwangerschaft nur selten verzehrt werden.", Language.German,
                documentType: DocumentType.Pdf);
     
            Assert.Equal(new[] { "Andere Fischsorten (z.B. Hai, Thunfisch, Aal und Seeteufel) weisen einen erhöhten Quecksilbergehalt auf und sollten deshalb in der Schwangerschaft nur selten verzehrt werden." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText028()
        {
            var result = Segmenter.Segment("Übung Präsens\n1. Ich ___ gern Tennis.\nspielen\nspielt\nspiele\n2. Karl __ mir den Ball.\ngebt\ngibt\ngeben\n3. Ihr ___ fast jeden Tag.\narbeitet\narbeite\narbeiten\n4. ___ Susi Deutsch?\nSprichst\nSprecht\nSpricht\n5. Wann ___ Karl und Julia? Heute?\nkommen\nkommt\nkomme\n\n\n\n\n", Language.German);
            Assert.Equal(new[] { "Übung Präsens", "1. Ich ___ gern Tennis.", "spielen", "spielt", "spiele", "2. Karl __ mir den Ball.", "gebt", "gibt", "geben", "3. Ihr ___ fast jeden Tag.", "arbeitet", "arbeite", "arbeiten", "4. ___ Susi Deutsch?", "Sprichst", "Sprecht", "Spricht", "5. Wann ___ Karl und Julia?", "Heute?", "kommen", "kommt", "komme" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText029()
        {
            var result = Segmenter.Segment("\n• einige Sorten Weichkäse  \n• rohes oder nicht ganz durchgebratenes Fleisch  \n• ungeputztes Gemüse und ungewaschener Salat  \n• nicht ganz durchgebratenes Hühnerfleisch, rohe oder nur weich gekochte Eier", Language.German);
            Assert.Equal(new[] { "• einige Sorten Weichkäse", "• rohes oder nicht ganz durchgebratenes Fleisch", "• ungeputztes Gemüse und ungewaschener Salat", "• nicht ganz durchgebratenes Hühnerfleisch, rohe oder nur weich gekochte Eier" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText030()
        {
            var result = Segmenter.Segment("Was sind die Konsequenzen der Abstimmung vom 12. Juni?", Language.German);
            Assert.Equal(new[] { "Was sind die Konsequenzen der Abstimmung vom 12. Juni?" }, result);
        }

        [Fact]
        public void CorrectlySegmentsText031()
        {
            var result = Segmenter.Segment("Was pro Jahr10. Zudem pro Jahr um 0.3 %11. Der gängigen Theorie nach erfolgt der Anstieg.", Language.German);
            Assert.Equal(new[] { "Was pro Jahr10.", "Zudem pro Jahr um 0.3 %11.", "Der gängigen Theorie nach erfolgt der Anstieg." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText032()
        {
            var result = Segmenter.Segment("s. vorherige Anmerkung.", Language.German);
            Assert.Equal(new[] { "s. vorherige Anmerkung." }, result);
        }

        [Fact]
        public void CorrectlySegmentsText033()
        {
            var result = Segmenter.Segment("Mit Inkrafttreten des Mindestlohngesetzes (MiLoG) zum 01. Januar 2015 werden in Bezug auf den Einsatz von Leistungs.", Language.German);
            Assert.Equal(new[] { "Mit Inkrafttreten des Mindestlohngesetzes (MiLoG) zum 01. Januar 2015 werden in Bezug auf den Einsatz von Leistungs." }, result);
        }
    }
}
