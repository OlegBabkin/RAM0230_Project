using System.Collections.Generic;

namespace Project.Infrastructure.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public IEnumerable<StudentDTO> StudentDTOs { get; set; }
        public IEnumerable<SubjectDTO> SubjectDTOs { get; set; }
    }
}
