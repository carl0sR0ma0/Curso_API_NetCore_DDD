using AutoMapper;
using Domain.DTOs.County;
using Domain.DTOs.UF;
using Domain.DTOs.User;
using Domain.DTOs.ZipCode;
using Domain.Entities;

namespace CrossCutting.Mappings
{
    public class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile()
        {
            #region User
            CreateMap<UserEntity, UserDTO>().ReverseMap();
            CreateMap<UserEntity, UserCreateResultDTO>().ReverseMap();
            CreateMap<UserEntity, UserUpdateResultDTO>().ReverseMap();
            #endregion

            #region UF
            CreateMap<UFEntity, UFDTO>().ReverseMap();
            #endregion

            #region County
            CreateMap<CountyEntity, CountyDTO>().ReverseMap();
            CreateMap<CountyEntity, CountyCompleteDTO>().ReverseMap();
            CreateMap<CountyEntity, CountyCreateResultDTO>().ReverseMap();
            CreateMap<CountyEntity, CountyUpdateResultDTO>().ReverseMap();
            #endregion

            #region ZipCode
            CreateMap<ZipCodeEntity, ZipCodeDTO>().ReverseMap();
            CreateMap<ZipCodeEntity, ZipCodeCreateResultDTO>().ReverseMap();
            CreateMap<ZipCodeEntity, ZipCodeUpdateResultDTO>().ReverseMap();
            #endregion
        }
    }
}
