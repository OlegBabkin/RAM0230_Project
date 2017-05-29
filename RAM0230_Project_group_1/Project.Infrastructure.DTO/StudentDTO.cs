using System.Collections.Generic;

namespace Project.Infrastructure.DTO
{
    public class StudentDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public ModeOfStudyDTO ModeOfStudyDTO { get; set; }
        public string Email { get; set; }
        public GroupDTO GroupDTO { get; set; }
        public IEnumerable<SubjectDTO> SubjectDTOs { get; set; }
        public IEnumerable<VisitDTO> VisitDTOs { get; set; }
    }
}
