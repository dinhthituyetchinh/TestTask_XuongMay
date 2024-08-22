using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace XuongMayBE.Data
{
    [Table("Tasks")]
    public class Tasks
    {
        [Key]
        public int TaskID { get; set; }

        [Required(ErrorMessage = "Tên công việc là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên công việc không được vượt quá 100 ký tự")]
        public string TaskName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "LineID phải là số dương")]
        public int LineID { get; set; }

        [ForeignKey("LineID")]
        [JsonIgnore]
        public virtual ProductionLine ProductionLine { get; set; }
    }
}