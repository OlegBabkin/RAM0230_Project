namespace Project.Infrastructure.DTO.Subject
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Lektorat { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Semester { get; set; }
        public decimal? LectureHours { get; set; }
        public decimal? PracticeHours { get; set; }
        public decimal? ExercisesHours { get; set; }
        public int ModeOfStudyId { get; set; }
        public string Language { get; set; }
    }
}
