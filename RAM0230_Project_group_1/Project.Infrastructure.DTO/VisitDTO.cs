using System;
using System.Collections.Generic;

namespace Project.Infrastructure.DTO
{
    public class VisitDTO
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string LessonType { get; set; }
        public int? PairNumber { get; set; }
        public int Subject_Techer_Id { get; set; }
        //public IEnumerable<StudentDTO> StudentDTOs { get; set; }
    }
}
