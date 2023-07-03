namespace MinimalChatApplication.DTO.ResponseDTO
{
    public class JWTTokenResponseDTO
    {
        public string? Token
        {
            get;
            set;
        }
        public UserReponseDTO profile { get; set; }
    }
}
