namespace LVS.Models
{
    public class GoodsReceipt
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int StorageLocationId { get; set; }
        public int Quantity { get; set; }

        public Article? Article { get; set; }
        public StorageLocation? StorageLocation { get; set; }
    }
}
