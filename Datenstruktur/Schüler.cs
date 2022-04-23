namespace Datenstruktur
{
    class Schüler
    {
        public string Name { get; set; }
        public string Klasse { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Klasse})";
        }
    }
}