namespace LVS.Models
{
    public class Artikel
    {
        public int Id { get; set; }
        public int Artikelnummer { get; set; }
        public string Artikelbezeichnung { get; set; } = "";
        public string Einheit { get; set; } = "";
        public int Bestand { get; set; }
        public int Mindestbestand { get; set; }
        public int Hoechstbestand { get; set; }

        public ICollection<LagerplatzBestand> LagerplatzBestaende { get; set; } = new List<LagerplatzBestand>();
    }
}
