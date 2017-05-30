using System.ComponentModel.DataAnnotations;

namespace Project.UI.WebMVCApp.Models.AuthViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}