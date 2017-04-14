namespace Project.Infrastructure.DTO.Visit
{
    public class VisitDTO
    {
        public int Id { get; set; }
        public System.DateTime? Date { get; set; }
        public string LessonType { get; set; }
        public int? PairNumber { get; set; }
        public int SubjectId { get; set; }
        public string SubjectTitle { get; set; }
    }
}
