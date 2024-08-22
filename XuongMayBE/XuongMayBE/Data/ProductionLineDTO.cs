using System.ComponentModel.DataAnnotations;

namespace XuongMayBE.Data
{
    public class ProductionLineDTO
    {
        public int LineID { get; set; }

        [Required(ErrorMessage = "Tên dây chuyền sản xuất là bắt buộc")]
        public string LineName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng công nhân phải lớn hơn 0")]
        public int WorkerCount { get; set; }
    }
}