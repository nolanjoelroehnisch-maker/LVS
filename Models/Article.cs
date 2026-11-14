using CsvHelper;

namespace LVS.Models
{
    [CsvRecord]
    public partial class Article
    {
        [CsvIgnore]
        public int Id { get; set;}

        public string ArticleNumber { get; set; } = "";
        public string ArticleName { get; set; } = "";
        public string Unit { get; set; } = "";
        public int TotalStock { get; set; }
        public int MinimumStock { get; set; }
        public int MaximumStock { get; set; }
        public string Brand { get; set; } = "";
        public string EAN { get; set; } = "";

        [CsvIgnore]
        public ICollection<LocationStock> LocationStocks { get; set; } = new List<LocationStock>();
    }
}