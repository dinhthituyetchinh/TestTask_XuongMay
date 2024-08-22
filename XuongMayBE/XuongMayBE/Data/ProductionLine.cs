using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace XuongMayBE.Data
{
    public class ProductionLine
    {
        public int LineID { get; set; }

        [Required(ErrorMessage = "Tên dây chuyền sản xuất là bắt buộc")]
        public string LineName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng công nhân phải lớn hơn 0")]
        public int WorkerCount { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}