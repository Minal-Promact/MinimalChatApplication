using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MinimalChatApplication.Model
{
    [Table("user")]
    public class User
    {
        [Key, Required]
        public string id { get; set; } = Guid.NewGuid().ToString();

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
