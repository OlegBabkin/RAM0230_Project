namespace Project.Infrastructure.DTO.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int RoleId { get; set; }
    }
}
