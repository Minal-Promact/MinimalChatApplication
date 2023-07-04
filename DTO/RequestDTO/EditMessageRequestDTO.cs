using System.ComponentModel.DataAnnotations;

namespace MinimalChatApplication.DTO.RequestDTO
{
    public class EditMessageRequestDTO
    {        

        [Required(ErrorMessage = "Please enter content.")]
        public string content { get; set; }
    }
}
