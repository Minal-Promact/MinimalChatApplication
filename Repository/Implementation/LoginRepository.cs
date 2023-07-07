using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MinimalChatApplication.Data;
using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.DTO.ResponseDTO;
using MinimalChatApplication.Helper;
using MinimalChatApplication.Model;
using MinimalChatApplication.Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinimalChatApplication.Repository.Implementation
{
    public class LoginRepository : ILoginRepository
    {
        private readonly EFDataContext dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginRepository(EFDataContext dbContext, IMapper mapper,IConfiguration configuration)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<User> CheckUserDetails(LoginRequestDTO loginRequestDTO)
        {
            loginRequestDTO.password = EncryptAndDecryptValue.Encryptword(loginRequestDTO.password); 
            var user = await dbContext.Users.FirstOrDefaultAsync(a=>a.email == loginRequestDTO.email && a.password == loginRequestDTO.password);
            if (user != null)
            {
                user.password = EncryptAndDecryptValue.Decryptword(user.password); ;
            }
            return user;
        }

        public async Task<JWTTokenResponseDTO> GetJWTTokenFromUserDetails(User user)
        {
            JWTTokenResponseDTO jWTTokenResponseDTO = new JWTTokenResponseDTO();            

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.id.ToString()),
                        new Claim("DisplayName", user.name),
                        new Claim("UserName", user.name),
                        new Claim("Email", user.email)
                    };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            jWTTokenResponseDTO.Token = new JwtSecurityTokenHandler().WriteToken(token);

            UserReponseDTO UserReponseDTO = _mapper.Map<User, UserReponseDTO>(user);
            jWTTokenResponseDTO.profile = UserReponseDTO;

            return jWTTokenResponseDTO;
        }
    }
}
