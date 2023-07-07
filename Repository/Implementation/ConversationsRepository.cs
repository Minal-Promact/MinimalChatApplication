using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MinimalChatApplication.Data;
using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.Model;
using MinimalChatApplication.Repository.Interface;
using System.Linq;

namespace MinimalChatApplication.Repository.Implementation
{
    public class ConversationsRepository : IConversationsRepository
    {
        private readonly EFDataContext dbContext;
        private readonly IMapper _mapper;
        public ConversationsRepository(EFDataContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<Message>> GetListMessage(string userId)
        {
            List<Message> lstSenderMessage = await dbContext.Messages.Where(a => a.senderId == userId).ToListAsync();
            List<Message> lstReceiverMessage = await dbContext.Messages.Where(a => a.receiverId == userId).ToListAsync();
            var result = lstSenderMessage.Concat(lstReceiverMessage).OrderBy(x => x.timestamp).ToList();
            return result;
        }

        public async Task<List<Message>> RetrieveConversationHistory(List<Message> lstMessage, FromQueryConversationHistory fromQueryConversationHistory)
        {           
            
            if (lstMessage != null && lstMessage.Count > 0)
            {
                if (fromQueryConversationHistory.Before == null)
                {
                    DateTime dateTime = DateTime.Now;
                    DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
                    fromQueryConversationHistory.Before = dateTimeOffset.ToUnixTimeSeconds();
                }

                lstMessage = lstMessage.Where(a => a.timestamp < fromQueryConversationHistory.Before).ToList();

                if (fromQueryConversationHistory.Count == null)
                {
                    fromQueryConversationHistory.Count = 20;
                }

                lstMessage = lstMessage.Take(fromQueryConversationHistory.Count).ToList();

                if (fromQueryConversationHistory.Sort == "asc")
                {
                    lstMessage = lstMessage.OrderBy(m => m.timestamp).ToList();
                }
                else if (fromQueryConversationHistory.Sort.ToLower() == "desc")
                {
                    lstMessage = lstMessage.OrderByDescending(m => m.timestamp).ToList();
                }                
            }
            return lstMessage;
        }


    }
}
