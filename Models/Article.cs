namespace LVS.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string ArticleNumber { get; set; } = "";
        public string ArticleName { get; set; } = "";
        public string Unit { get; set; } = "";
        public int TotalStock { get; set; }
        public int MinimumStock { get; set; }
        public int MaximumStock { get; set; }

        public ICollection<LocationStock> LocationStocks { get; set; } = new List<LocationStock>();
    }
}
