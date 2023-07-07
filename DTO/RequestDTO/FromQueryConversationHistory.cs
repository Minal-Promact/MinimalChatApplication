using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MinimalChatApplication.DTO.RequestDTO
{
    public class FromQueryConversationHistory
    {
        public FromQueryConversationHistory()
        {
            DateTime dateTime = DateTime.Now;
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);            
            Before = dateTimeOffset.ToUnixTimeSeconds(); 
        }

        
        public long Before { get; set; }

        
        [DefaultValue("20")]
        public int Count { get; set; } = 20;

        
        [DefaultValue("asc")]
        public string Sort { get; set; } = "asc";
       
    }
}
