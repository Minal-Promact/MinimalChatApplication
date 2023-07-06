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
            return await dbContext.Messages.Where(a => a.senderId == userId).ToListAsync();
        }

        public async Task<List<Message>> RetrieveConversationHistory(List<Message> lstMessage, long? before = null, int? count = null, string? sort = null)
        {           
            
            if (lstMessage != null && lstMessage.Count > 0)
            {
                if (before == null)
                {
                    DateTime dateTime = DateTime.Now;
                    DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
                    before = dateTimeOffset.ToUnixTimeSeconds();
                }

                lstMessage = lstMessage.Where(a => a.timestamp < before).ToList();

                if (count == null)
                {
                    count = 20;
                }

                lstMessage = lstMessage.Take(count.Value).ToList();

                if (sort == null)
                {
                    lstMessage = lstMessage.OrderBy(m => m.timestamp).ToList();
                }
                else if (sort.ToLower() == "desc")
                {
                    lstMessage = lstMessage.OrderByDescending(m => m.timestamp).ToList();
                }                
            }
            return lstMessage;
        }


    }
}
