namespace LVS.Models
{
    public class Warehouse
    {
      public int Id { get; set; }
      public string WarehouseNumber { get; set; } = "";
      public string Name { get; set; } = "";
      public string Address { get; set; } = "";
      public List<StorageLocation> StorageLocations { get; set; } = new();
      
      
    }

}
