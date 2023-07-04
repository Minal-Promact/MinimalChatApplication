using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.Model;

namespace MinimalChatApplication.Repository.Interface
{
    public interface IMessagesRepository
    {
        Task<Message> SendMessage(Message messages);
        Task<Message> GetndCheckMessageById(string messageId);
        Task<Message> EditMessage(Message message);
        void DeleteMessage(Message message);
    }
}
