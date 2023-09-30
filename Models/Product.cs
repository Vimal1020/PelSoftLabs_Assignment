using System.ComponentModel.DataAnnotations.Schema;

namespace PelSoftLabsTest.Models
{
    [Table("tbl_Product")]
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }

        [Column(TypeName = "Date")]
        public DateTime MfgDate { get; set; }
        public string Category { get; set; }

    }
}
