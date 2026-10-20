namespace LVS.Models
{
    public class StorageLocation
    {
        public int Id { get; set;  }

        public string LocationCode { get; set; } = "";

        public string Name { get; set; } = "";

        public int Capacity { get; set; }

        public int WarehouseId { get; set; } 

        public Warehouse? Warehouse { get; set; }

        public ICollection<LocationStock> LocationStocks { get; set; } = new List<LocationStock>();
    }
}
