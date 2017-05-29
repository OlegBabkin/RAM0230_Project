using System.Collections.Generic;

namespace Project.Infrastructure.DTO
{
    public class SubjectTeacherDTO
    {
        public int Id { get; set; }
        public SubjectDTO SubjectDTO { get; set; }
        public UserDTO UserDTO { get; set; }
        public IEnumerable<VisitDTO> VisitDTOs { get; set; }
    }
}
