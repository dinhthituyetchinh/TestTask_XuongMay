using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XuongMayBE.Data
{
    public class Tasks
    {
        [Key]
        public int TaskID { get; set; }
        public string TaskName { get; set; }

        [ForeignKey("ProductionLine")]
        public int LineID { get; set; }
        public ProductionLine ProductionLine { get; set; }

       // [ForeignKey("Order")]
       // public int OrderID { get; set; }
       // public Order Order { get; set; }
    }
}
