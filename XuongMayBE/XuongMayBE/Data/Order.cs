using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace XuongMayBE.Data
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string ?OrderName { get; set; }  
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        public decimal TotalAmount => (decimal)(Product != null ? Price * Quantity : 0);
    }
}
