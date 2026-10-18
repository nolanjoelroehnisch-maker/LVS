namespace LVS.Models
{
    public class Lagerplatz
    {
        public int Id { get; set;  }

        public string Lagerplatznummer { get; set; } = "";

        public string Bezeichnung { get; set; } = "";

        public int Kapazitaet { get; set; }

        public int LagerId { get; set; } 

        public Lager? Lager { get; set; }

        public ICollection<LagerplatzBestand> LagerplatzBestaende { get; set; } = new List<LagerplatzBestand>();
    }
}
