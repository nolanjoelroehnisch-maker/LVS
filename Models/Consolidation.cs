namespace LVS.Models
{
    public class Consolidation
    {
        public int Id { get; set; }
        public string Status { get; set; } = "";

        public List<ConsolidationPosition> Positions { get; set; } = new();
    }
}