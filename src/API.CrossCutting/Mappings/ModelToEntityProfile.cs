using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UserEntity>().ReverseMap();

            CreateMap<UFModel, UFEntity>().ReverseMap();

            CreateMap<CountyModel, CountyEntity>().ReverseMap();

            CreateMap<ZipCodeModel, ZipCodeEntity>().ReverseMap();
        }
    }
}
