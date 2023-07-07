using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.Model;

namespace MinimalChatApplication.Repository.Interface
{
    public interface IConversationsRepository
    {
        Task<List<Message>> GetListMessage(string userId);
        Task<List<Message>> RetrieveConversationHistory(List<Message> lstMessage, FromQueryConversationHistory fromQueryConversationHistory);
    }
}
