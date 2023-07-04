using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinimalChatApplication.Data;
using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.DTO.ResponseDTO;
using MinimalChatApplication.Model;
using MinimalChatApplication.Repository.Interface;

namespace MinimalChatApplication.Repository.Implementation
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly EFDataContext dbContext;
        private readonly IMapper _mapper;
        public MessagesRepository(EFDataContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Message> SendMessage(Message message)
        {  
            DateTime dateTime = DateTime.Now.AddDays(1);
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
            message.timestamp = dateTimeOffset.ToUnixTimeSeconds();

            await dbContext.Messages.AddAsync(message);
            await dbContext.SaveChangesAsync();
            
            return message;
        }

        public async Task<Message> GetndCheckMessageById(string messageId)
        {
            return await dbContext.Messages.Where(e => e.id == messageId).FirstOrDefaultAsync();           
        }

        public async Task<Message> EditMessage(Message message)
        {
            DateTime dateTime = DateTime.Now;
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
            message.timestamp = dateTimeOffset.ToUnixTimeSeconds();

            dbContext.Messages.Update(message);
            await dbContext.SaveChangesAsync();

            return message;
        }

        public void DeleteMessage(Message message)
        {
            dbContext.Messages.Remove(message);
            dbContext.SaveChangesAsync();
        }

    }
}
