using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MinimalChatApplication.DTO.RequestDTO
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "Please enter email address.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
