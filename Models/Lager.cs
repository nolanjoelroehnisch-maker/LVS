namespace LVS.Models
{
    public class Lager
    {
      public int Id { get; set; }
      public string LagerNummer { get; set; } = "";
      public string Bezeichnung { get; set; } = "";
      public string Adresse { get; set; } = "";
      public List<Lagerplatz> Lagerplaetze { get; set; } = new();
      
      
    }

}
