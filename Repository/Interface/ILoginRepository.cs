using Microsoft.AspNetCore.Mvc;
using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.DTO.ResponseDTO;
using MinimalChatApplication.Model;

namespace MinimalChatApplication.Repository.Interface
{
    public interface ILoginRepository
    {
        Task<User> CheckUserDetails(LoginRequestDTO loginRequestDTO);
        Task<JWTTokenResponseDTO> GetJWTTokenFromUserDetails(User user);
    }
}
