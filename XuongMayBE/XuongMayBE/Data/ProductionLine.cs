using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XuongMayBE.Data
{
    [Table("ProductionLines")]
    public class ProductionLine
    {
        [Key]
        public int LineID { get; set; }
        [Required]
        public string LineName { get; set; }
        public int WorkerCount { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }

    }
}