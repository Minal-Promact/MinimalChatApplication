using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.DTO.ResponseDTO;
using MinimalChatApplication.Model;

namespace MinimalChatApplication.Repository.Interface
{
    public interface IRegisterRepository
    {
        Task<User> CheckEmailExistsInUser(string email);
        Task<UserReponseDTO> RegisterUser(UserRequestDTO userRequestDTO);
    }
}
