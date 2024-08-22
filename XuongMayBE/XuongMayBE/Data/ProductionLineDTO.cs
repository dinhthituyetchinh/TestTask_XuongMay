namespace XuongMayBE.Data
{
    public class ProductionLineDTO
    {
        public int LineID { get; set; }
        public string LineName { get; set; }
        public int WorkerCount { get; set; }
        public List<TaskDTO> ProductionTasks { get; set; }
    }

}
