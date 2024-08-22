using System.ComponentModel.DataAnnotations;

namespace XuongMayBE.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount =>(decimal)(Price * Quantity); 
        public int ProductID { get; set; }
    }
}
