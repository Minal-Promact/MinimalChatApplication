using AutoMapper;
using MinimalChatApplication.DTO.RequestDTO;
using MinimalChatApplication.DTO.ResponseDTO;
using MinimalChatApplication.Model;

namespace MinimalChatApplication.AutomapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UserReponseDTO, User>().ForMember(dest => dest.id, opt => opt.MapFrom(src => src.userId));
            CreateMap<User, UserReponseDTO>().ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.id));

            CreateMap<Message, SendMessagesRequestDTO>().ReverseMap();
            CreateMap<Message, EditMessageRequestDTO>().ReverseMap();

            CreateMap<User, UserRequestDTO>().ReverseMap();
            
        }
    }
}
