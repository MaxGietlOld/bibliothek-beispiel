using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Datenstruktur
{
    class Daten
    {
        public Dictionary<string, Buch> bücher { get; set; }
        public Dictionary<string, Schüler> schüler { get; set; }
        public List<Ausleihe> ausleihen { get; set; }

        public void GebeAusleihenAus()
        {
            Console.WriteLine(" - - - - - ");
            Console.WriteLine("Ausleihen: ");
            foreach (var ausleihe in ausleihen)
            {
                var ausleiher = schüler[ausleihe.SchülerId];
                var buch = bücher[ausleihe.BuchId];
                if (ausleihe.Aktuell)
                {
                    Console.WriteLine(
                        $"{ausleiher} leiht {buch} aktuell aus");
                }
                else
                {
                    Console.WriteLine(
                        $"{ausleiher} hat {buch} in der Vergangenheit ausgeliehen");
                }
            }
        }

        public List<string> SucheSchüler(string suche)
        {
            var ergebnisse = new List<string>();
            foreach (var (schülerId, schüler) in schüler)
            {
                if (schüler.Name.Contains(suche) || schüler.Klasse.Contains(suche))
                {
                    ergebnisse.Add(schülerId);
                }
            }

            return ergebnisse;
        }

        public List<string> SucheBücher(string suche)
        {
            var ergebnisse = new List<string>();
            foreach (var (buchId, buch) in bücher)
            {
                if (buch.Name.Contains(suche) || buch.Isbn.Contains(suche))
                {
                    ergebnisse.Add(buchId);
                }
            }

            return ergebnisse;
        }

        public void Speichern()
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText("daten.json", json);
        }

        public static Daten Laden()
        {
            var json = File.ReadAllText("daten.json");
            return JsonConvert.DeserializeObject<Daten>(json);
        }

        public static string GeneriereId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}