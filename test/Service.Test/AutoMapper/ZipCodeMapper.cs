using Domain.DTOs.ZipCode;
using Domain.Entities;
using Domain.Models;
using Faker;

namespace Service.Test.AutoMapper
{
    public class ZipCodeMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível mapear o modelos de CEP.")]
        public void MapTheModelsToZipCode()
        {
            var model = new ZipCodeModel
            {
                Id = Guid.NewGuid(),
                ZipCode = Address.ZipCode(),
                PublicPlace = Address.StreetName(),
                Number = RandomNumber.Next(1, 10000).ToString(),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                CountyId = Guid.NewGuid()
            };

            var listEntity = new List<ZipCodeEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new ZipCodeEntity()
                {
                    Id = Guid.NewGuid(),
                    ZipCode = Address.ZipCode(),
                    PublicPlace = Address.StreetName(),
                    Number = RandomNumber.Next(1, 10000).ToString(),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    CountyId = Guid.NewGuid(),
                    County = new CountyEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Address.City(),
                        CodeIBGE = RandomNumber.Next(1, 10000),
                        CreateAt = DateTime.Now,
                        UpdateAt = DateTime.Now,
                        UFId = Guid.NewGuid(),
                        UF = new UFEntity
                        {
                            Id = Guid.NewGuid(),
                            Name = Address.UsState(),
                            Initials = Address.UsState().Substring(1, 3)
                        }
                    }
                };
                listEntity.Add(item);
            }

            // Model => Entity
            var entity = Mapper.Map<ZipCodeEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.ZipCode, model.ZipCode);
            Assert.Equal(entity.PublicPlace, model.PublicPlace);
            Assert.Equal(entity.Number, model.Number);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);
            Assert.Equal(entity.CountyId, model.CountyId);

            // Entity => DTO
            var zipCodeDTO = Mapper.Map<ZipCodeDTO>(entity);
            Assert.Equal(zipCodeDTO.Id, entity.Id);
            Assert.Equal(zipCodeDTO.ZipCode, entity.ZipCode);
            Assert.Equal(zipCodeDTO.PublicPlace, entity.PublicPlace);
            Assert.Equal(zipCodeDTO.Number, entity.Number);
            Assert.Equal(zipCodeDTO.CountyId, entity.CountyId);

            var zipCodeComplete = Mapper.Map<ZipCodeDTO>(listEntity.FirstOrDefault());
            Assert.Equal(zipCodeComplete.Id, listEntity.FirstOrDefault().Id);
            Assert.Equal(zipCodeComplete.ZipCode, listEntity.FirstOrDefault().ZipCode);
            Assert.Equal(zipCodeComplete.PublicPlace, listEntity.FirstOrDefault().PublicPlace);
            Assert.Equal(zipCodeComplete.Number, listEntity.FirstOrDefault().Number);
            Assert.Equal(zipCodeComplete.CountyId, listEntity.FirstOrDefault().CountyId);
            Assert.NotNull(zipCodeComplete.County);
            Assert.NotNull(zipCodeComplete.County.UF);

            var listDTO = Mapper.Map<List<ZipCodeDTO>>(listEntity);
            Assert.True(listDTO.Count() == listEntity.Count());
            for (int i = 0; i < listDTO.Count(); i++)
            {
                Assert.Equal(listDTO[i].Id, listEntity[i].Id);
                Assert.Equal(listDTO[i].ZipCode, listEntity[i].ZipCode);
                Assert.Equal(listDTO[i].PublicPlace, listEntity[i].PublicPlace);
                Assert.Equal(listDTO[i].Number, listEntity[i].Number);
                Assert.Equal(listDTO[i].CountyId, listEntity[i].CountyId);
            }

            var zipCodeCreateResultDTO = Mapper.Map<ZipCodeCreateResultDTO>(entity);
            Assert.Equal(zipCodeCreateResultDTO.Id, entity.Id);
            Assert.Equal(zipCodeCreateResultDTO.ZipCode, entity.ZipCode);
            Assert.Equal(zipCodeCreateResultDTO.PublicPlace, entity.PublicPlace);
            Assert.Equal(zipCodeCreateResultDTO.Number, entity.Number);
            Assert.Equal(zipCodeCreateResultDTO.CountyId, entity.CountyId);
            Assert.Equal(zipCodeCreateResultDTO.CreateAt, entity.CreateAt);

            var zipCodeUpdateResultDTO = Mapper.Map<ZipCodeUpdateResultDTO>(entity);
            Assert.Equal(zipCodeUpdateResultDTO.Id, entity.Id);
            Assert.Equal(zipCodeUpdateResultDTO.ZipCode, entity.ZipCode);
            Assert.Equal(zipCodeUpdateResultDTO.PublicPlace, entity.PublicPlace);
            Assert.Equal(zipCodeUpdateResultDTO.Number, entity.Number);
            Assert.Equal(zipCodeUpdateResultDTO.CountyId, entity.CountyId);
            Assert.Equal(zipCodeUpdateResultDTO.UpdateAt, entity.UpdateAt);

            // DTO => Model
            zipCodeDTO.Number = "";
            var zipCodeModel = Mapper.Map<ZipCodeModel>(zipCodeDTO);
            Assert.Equal(zipCodeModel.Id, zipCodeDTO.Id);
            Assert.Equal(zipCodeModel.ZipCode, zipCodeDTO.ZipCode);
            Assert.Equal(zipCodeModel.PublicPlace, zipCodeDTO.PublicPlace);
            Assert.Equal(zipCodeModel.CountyId, zipCodeDTO.CountyId);
            Assert.Equal("S/N", zipCodeModel.Number);

            // Model => CreateDTO
            var zipCodeCreateDTO = Mapper.Map<ZipCodeCreateDTO>(zipCodeModel);
            Assert.Equal(zipCodeCreateDTO.ZipCode, zipCodeModel.ZipCode);
            Assert.Equal(zipCodeCreateDTO.PublicPlace, zipCodeModel.PublicPlace);
            Assert.Equal(zipCodeCreateDTO.Number, zipCodeModel.Number);
            Assert.Equal(zipCodeCreateDTO.CountyId, zipCodeModel.CountyId);

            var zipCodeUpdateDTO = Mapper.Map<ZipCodeUpdateDTO>(zipCodeModel);
            Assert.Equal(zipCodeUpdateDTO.ZipCode, zipCodeModel.ZipCode);
            Assert.Equal(zipCodeUpdateDTO.PublicPlace, zipCodeModel.PublicPlace);
            Assert.Equal(zipCodeUpdateDTO.Number, zipCodeModel.Number);
            Assert.Equal(zipCodeUpdateDTO.CountyId, zipCodeModel.CountyId);
        }
    }
}
