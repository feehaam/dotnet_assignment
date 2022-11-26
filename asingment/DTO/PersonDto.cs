namespace asingment.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TasksDto> Orders { get; set; }
    }
}
