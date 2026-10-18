namespace LVS.Models
{
    public class Verdichtung
    {
        public int Id { get; set; }
        public string Status { get; set; } = "";

        public List<VerdichtungsPosition> Positionen { get; set; } = new();
    }
}