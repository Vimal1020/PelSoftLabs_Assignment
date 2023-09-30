namespace PelSoftLabsTest.Models
{
    public class SearchProductCriteria
    {
        public string ProductName { get; set; }
        public string Size { get; set; }
        public decimal? Price { get; set; }
        public DateTime? MfgDate { get; set; }
        public string Category { get; set; }
        public string Conjunction { get; set; }
        public List<Product> SearchResults { get; set; }
    }
}
