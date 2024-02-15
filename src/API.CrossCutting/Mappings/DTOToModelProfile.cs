using AutoMapper;
using Domain.DTOs.County;
using Domain.DTOs.UF;
using Domain.DTOs.User;
using Domain.DTOs.ZipCode;
using Domain.Models;

namespace CrossCutting.Mappings
{
    public class DTOToModelProfile : Profile
    {
        public DTOToModelProfile()
        {
            #region User
            CreateMap<UserDTO, UserModel> ().ReverseMap();
            CreateMap<UserCreateDTO, UserModel> ().ReverseMap();
            CreateMap<UserUpdateDTO, UserModel> ().ReverseMap();
            #endregion

            #region UF
            CreateMap<UFDTO, UFModel> ().ReverseMap();
            #endregion

            #region County
            CreateMap<CountyDTO, CountyModel> ().ReverseMap();
            CreateMap<CountyCreateDTO, CountyModel> ().ReverseMap();
            CreateMap<CountyUpdateDTO, CountyModel> ().ReverseMap();
            #endregion

            #region ZipCode
            CreateMap<ZipCodeDTO, ZipCodeModel> ().ReverseMap();
            CreateMap<ZipCodeCreateDTO, ZipCodeModel> ().ReverseMap();
            CreateMap<ZipCodeUpdateDTO, ZipCodeModel> ().ReverseMap();
            #endregion
        }
    }
}
