using System.ComponentModel.DataAnnotations;

namespace MinimalChatApplication.DTO.RequestDTO
{
    public class SendMessagesRequestDTO
    {
        [Required(ErrorMessage = "Please enter receiverId.")]
        public string receiverId { get; set; }

        [Required(ErrorMessage = "Please enter content.")]
        public string content { get; set; }
    }
}
