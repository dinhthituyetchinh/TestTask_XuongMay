using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XuongMayBE.Models
{
    public class ProductionLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Đánh dấu là IDENTITY
        public int LineID { get; set; }
        public string LineName { get; set; }
        public int WorkerCount { get; set; }
    }
}