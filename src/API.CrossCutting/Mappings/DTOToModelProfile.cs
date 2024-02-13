using AutoMapper;
using Domain.DTOs.User;
using Domain.Models;

namespace CrossCutting.Mappings
{
    public class DTOToModelProfile : Profile
    {
        public DTOToModelProfile()
        {
            CreateMap<UserDTO, UserModel> ().ReverseMap();

            CreateMap<UserCreateDTO, UserModel> ().ReverseMap();
            
            CreateMap<UserUpdateDTO, UserModel> ().ReverseMap();
        }
    }
}
