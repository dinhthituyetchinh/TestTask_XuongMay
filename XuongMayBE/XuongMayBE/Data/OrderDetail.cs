using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace XuongMayBE.Data
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Đánh dấu là IDENTITY
        public int OrderDetailID { get; set; }
        [ForeignKey("OrderID")]
        public int OrderID { get; set; }
        public Order Order { get; set; } // Khóa ngoại đến bảng Order

        //[ForeignKey("OrderID")]
        //public int ProductID { get; set; }
        //public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
