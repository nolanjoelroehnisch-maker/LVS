namespace LVS.Models
{
    public class StockMovement
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int StorageLocationId { get; set; }
        public int Quantity { get; set; }

        public Article? Article { get; set; }
        public StorageLocation? StorageLocation { get; set; }
        public DateTime Timestamp { get; set; }
        public string MovementType { get; set; } = "";

    }
}
