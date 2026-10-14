namespace LVS.Models
{
    public class Warenausgang
    {
        public int Id { get; set; }
        public int ArtikelId { get; set; }
        public int LagerplatzId { get; set; }
        public int Menge { get; set; }
        public int SendungsId { get; set; }
    }

    
}
