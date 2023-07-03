using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinimalChatApplication.Data;
using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.DTO.ResponseDTO;
using MinimalChatApplication.Model;
using MinimalChatApplication.Repository.Interface;

namespace MinimalChatApplication.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly EFDataContext dbContext;
        private readonly IMapper _mapper;

        public UserRepository(EFDataContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<User>> GetListOfUser()
        {
            var user = await dbContext.Users.ToListAsync();
            return user;
        }

        

    }
}
