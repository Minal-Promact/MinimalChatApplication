using System.ComponentModel.DataAnnotations;

namespace MinimalChatApplication.DTO.RequestDTO
{
    public class FromQueryRequestLogging
    {
        public FromQueryRequestLogging()
        {
            DateTime dateTime = DateTime.Now.AddMinutes(5);
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
            StartDateTime = dateTimeOffset.ToUnixTimeSeconds();

            DateTime dateTimeEnd = DateTime.Now;
            DateTimeOffset dateTimeOffsetEnd = new DateTimeOffset(dateTimeEnd);
            EndDateTime = dateTimeOffset.ToUnixTimeSeconds();
        }

        
        public long? StartDateTime { get; set; }

        
        public long? EndDateTime { get; set; }
    }
}
