using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XuongMayBE.Data
{
    [Table("Tasks")]
    public class Tasks
    {
        [Key]
        public int TaskID { get; set; }
        [Required]
        public string TaskName { get; set; }
        public int LineID { get; set; }
        [ForeignKey("LineID")]
        public virtual ProductionLine ProductionLine { get; set; }
    }
}