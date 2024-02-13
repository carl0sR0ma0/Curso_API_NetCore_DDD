using AutoMapper;
using Domain.DTOs.User;
using Domain.Entities;

namespace CrossCutting.Mappings
{
    public class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<UserEntity, UserDTO>().ReverseMap();

            CreateMap<UserEntity, UserCreateResultDTO>().ReverseMap();

            CreateMap<UserEntity, UserUpdateResultDTO>().ReverseMap();
        }
    }
}
