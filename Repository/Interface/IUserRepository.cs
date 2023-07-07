using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.DTO.ResponseDTO;
using MinimalChatApplication.Model;

namespace MinimalChatApplication.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<UserReponseDTO>> GetListOfUser();
    }
}
