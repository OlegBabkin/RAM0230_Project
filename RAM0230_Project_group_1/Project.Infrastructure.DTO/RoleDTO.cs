using System.Collections.Generic;

namespace Project.Infrastructure.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserDTO> UserDTOs { get; set; }
    }
}
