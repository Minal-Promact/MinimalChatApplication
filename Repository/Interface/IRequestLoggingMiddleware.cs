using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.DTO.ResponseDTO;
using MinimalChatApplication.Model;

namespace MinimalChatApplication.Repository.Interface
{
    public interface IRequestLoggingMiddleware
    {
        Task<RequestLogging> PostRequestLoggingMiddleware(LogResponse logResponse);
        Task<List<RequestLogging>> GetRequestLoggingMiddleware(FromQueryRequestLogging fromQueryRequestLogging);
    }
}
