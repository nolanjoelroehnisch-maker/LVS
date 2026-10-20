namespace LVS.Models
{
    public class ConsolidationPosition
    {
        public int Id { get; set; }
        public int ConsolidationId { get; set; }
        public int ArticleId { get; set; }
        public int Quantity { get; set; }
        public Consolidation? Consolidation { get; set; }
        public Article? Article { get; set; }
    }
}