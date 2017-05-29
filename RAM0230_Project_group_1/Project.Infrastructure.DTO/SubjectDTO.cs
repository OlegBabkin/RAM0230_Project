using System.Collections.Generic;

namespace Project.Infrastructure.DTO
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Lektorat { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Semester { get; set; }
        public decimal LectureHours { get; set; }
        public decimal PracticeHours { get; set; }
        public decimal ExercisesHours { get; set; }
        public string Language { get; set; }
        public ModeOfStudyDTO ModeOfStudyDTO { get; set; }
        public IEnumerable<SubjectTeacherDTO> SubjectTeacherDTOs { get; set; }
        public IEnumerable<GroupDTO> GroupDTOs { get; set; }
        public IEnumerable<StudentDTO> StudentDTOs { get; set; }
    }
}
