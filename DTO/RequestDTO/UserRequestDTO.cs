using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MinimalChatApplication.DTO.RequestDTO
{
    public class UserRequestDTO
    {
        [StringLength(20, ErrorMessage = "Name should be maximum 20 length.")]
        [Required(ErrorMessage = "Please Enter Employee Name.")]
        [RegularExpression(pattern: "[a-zA-Z ]*$", ErrorMessage = "Please enter only alphabets.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter email address.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
