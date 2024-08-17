using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace XuongMayBE.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string ?Name { get; set; }
        public string ?Description { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Range(0, 100)]
        public int Quantity { get; set; }
    }
}
