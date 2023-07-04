using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalChatApplication.Model
{
    [Table("message")]
    public class Message
    {
        [Key, Required]
        public string id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Please enter senderId.")]
        public string senderId { get; set; }

        [Required(ErrorMessage = "Please enter receiverId.")]
        public string receiverId { get; set; }

        [Required(ErrorMessage = "Please enter content.")]
        public string content { get; set; }
        
        public long timestamp { get; set; }

    }
}
