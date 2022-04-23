namespace Datenstruktur
{
    class Buch
    {
        public string Name { get; set; }
        public string Isbn { get; set; }

        public override string ToString()
        {
            return $"{Name} (ISBN: {Isbn})";
        }
    }
}