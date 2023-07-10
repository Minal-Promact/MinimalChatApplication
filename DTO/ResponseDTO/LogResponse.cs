namespace MinimalChatApplication.DTO.ResponseDTO
{
    public class LogResponse
    {
        public string iPOfCaller { get; set; }
        public string method { get; set; }
        public string path { get; set; }
        public QueryString queryString { get; set; }
        public string requestBody { get; set; }
        public long timeOfCall { get; set; }
        public string userName { get; set; }
    }
}
