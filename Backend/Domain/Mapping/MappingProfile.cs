using AutoMapper;
using Domain.DTOs;
using Domain.Model;
using Attribute = Domain.Model.Attribute;

namespace Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Theme, ThemeDTO>().ReverseMap();
            CreateMap<Card, CardDTO>().ReverseMap();
            CreateMap<Attribute, AttributeDTO>().ReverseMap();
            CreateMap<Game, GameDTO>().ReverseMap();
        }
    }
}
