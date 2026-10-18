namespace LVS.Models
{
    public class Lagerbewegung
    {
        public int Id { get; set; }
        public int ArtikelId { get; set; }
        public int LagerplatzId { get; set; }
        public int Menge { get; set; }

        public Artikel? Artikel { get; set; }
        public Lagerplatz? Lagerplatz { get; set; }
        public DateTime Zeitpunkt { get; set; }
        public string Bewegungsart { get; set; } = "";

    }
}
