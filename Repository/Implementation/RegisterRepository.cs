using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinimalChatApplication.Data;
using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.DTO.ResponseDTO;
using MinimalChatApplication.Helper;
using MinimalChatApplication.Model;
using MinimalChatApplication.Repository.Interface;
using System.Security.Cryptography.Xml;

namespace MinimalChatApplication.Repository.Implementation
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly EFDataContext dbContext;
        private readonly IMapper _mapper;

        public RegisterRepository(EFDataContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<User> CheckEmailExistsInUser(string email)
        {
            return await dbContext.Users.FirstOrDefaultAsync(a => a.email == email);
        }

        public async Task<UserReponseDTO> RegisterUser(UserRequestDTO userRequestDTO)
        {
            var user = _mapper.Map<UserRequestDTO, User>(userRequestDTO);
            // Encrypted password
            user.password = EncryptAndDecryptValue.Encryptword(user.password);            
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var userReponseDTO = _mapper.Map<User, UserReponseDTO>(user);
            return userReponseDTO;
        }
    }
}
