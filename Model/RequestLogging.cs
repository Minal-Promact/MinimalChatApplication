using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalChatApplication.Model
{
    [Table("requestLoggingMiddleware")]
    public class RequestLogging
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string iPOfCaller { get; set; }
        public string method { get; set; }
        public string path { get; set; }
        public string queryString { get; set; }
        public string requestBody { get; set; }
        public long timeOfCall { get; set; }
        public string userName { get; set; }
    }
}
