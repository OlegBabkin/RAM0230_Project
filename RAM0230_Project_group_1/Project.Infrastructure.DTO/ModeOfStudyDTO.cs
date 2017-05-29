using System.Collections.Generic;

namespace Project.Infrastructure.DTO
{
    public class ModeOfStudyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<StudentDTO> StudentDTOs { get; set; }
        public IEnumerable<SubjectDTO> SubjectDTOs { get; set; }
    }
}
