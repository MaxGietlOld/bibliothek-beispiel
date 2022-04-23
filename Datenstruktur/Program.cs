using System;
using System.Collections.Generic;

namespace Datenstruktur
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Lade Daten von JSON Datei
            var daten = Daten.Laden();
            
            // Generiere Beispiel-Daten
            // var daten = GeneriereBeispielDaten();
            
            // Suche nach '4a'
            Console.WriteLine(" - - - - - ");
            Console.WriteLine("Suche nach '4a':");
            var ergebnisse = daten.SucheSchüler("4a");
            foreach (var schülerId in ergebnisse)
            {
                var schüler = daten.schüler[schülerId];
                Console.WriteLine(schüler);
            }

            // Suche nach 'Johann'
            Console.WriteLine(" - - - - - ");
            Console.WriteLine("Suche nach 'Johann':");
            ergebnisse = daten.SucheSchüler("Johann");
            foreach (var schülerId in ergebnisse)
            {
                var schüler = daten.schüler[schülerId];
                Console.WriteLine(schüler);
            }

            // Speichere die id von Johann Sebastian (erstes Suchergebnis)
            var johannId = ergebnisse[0];

            // Lösche alle aktuellen Ausleihen
            daten.ausleihen.Clear();
            
            // Leihe alle Bücher für Johann aus
            foreach (var buchId in daten.bücher.Keys)
            {
                daten.ausleihen.Add(new Ausleihe()
                {
                    Aktuell = true,
                    BuchId = buchId,
                    SchülerId = johannId,
                });
            }

            daten.GebeAusleihenAus();

            // Setze die erste Ausleihe auf nicht-aktuell
            daten.ausleihen[0].Aktuell = false;

            daten.GebeAusleihenAus();

            // Speicher die Daten in der JSON Datei
            daten.Speichern();
        }
        
        public static Daten GeneriereBeispielDaten()
        {
            var beispielDaten = new Daten();
            beispielDaten.bücher = new Dictionary<string, Buch>
            {
                {
                    Daten.GeneriereId(), new Buch
                    {
                        Isbn = "IOSDFJNB",
                        Name = "Pitt, der freche Seeräuber (Lesebilderbuch)"
                    }
                },
                {
                    Daten.GeneriereId(), new Buch
                    {
                        Isbn = "KSJSDLFKJ",
                        Name = "Jona und Joni - Abenteuer in der Schule - Bachems erstes Lesen"
                    }
                }
            };
            beispielDaten.schüler = new Dictionary<string, Schüler>
            {
                {
                    Daten.GeneriereId(), new Schüler
                    {
                        Klasse = "4a",
                        Name = "Johann Sebastian"
                    }
                },
                {
                    Daten.GeneriereId(), new Schüler()
                    {
                        Klasse = "4a",
                        Name = "Karl Friedrich"
                    }
                },
                {
                    Daten.GeneriereId(), new Schüler
                    {
                        Klasse = "3b",
                        Name = "Wolfgang Amadeus"
                    }
                }
            };

            beispielDaten.ausleihen = new List<Ausleihe>();

            return beispielDaten;
        }
    }
}