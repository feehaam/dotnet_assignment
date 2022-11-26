namespace asingment.Dto
{
    public class TasksDto
    {
        public int Id { get; set; }
        public bool IsComplete { get; set; }
        public string TaskName { get; set; }
        public DateTime DelivaryTime { get; set; }
        public string OrderFor { get; set; }
    }
}
