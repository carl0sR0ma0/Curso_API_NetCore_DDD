using Domain.DTOs.County;
using Domain.Entities;
using Domain.Models;
using Faker;

namespace Service.Test.AutoMapper
{
    public class CountyMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível mapear o modelos de Município.")]
        public void MapTheModelsToCounty()
        {
            var model = new CountyModel
            {
                Id = Guid.NewGuid(),
                Name = Address.City(),
                CodeIBGE = RandomNumber.Next(1, 10000),
                UFId = Guid.NewGuid(),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            var listEntity = new List<CountyEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new CountyEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Address.City(),
                    CodeIBGE = RandomNumber.Next(1, 10000),
                    UFId = Guid.NewGuid(),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    UF = new UFEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Address.UsState(),
                        Initials = Address.UsState().Substring(1, 3)
                    }
                };
                listEntity.Add(item);
            }

            // Model => Entity
            var entity = Mapper.Map<CountyEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.CodeIBGE, model.CodeIBGE);
            Assert.Equal(entity.UFId, model.UFId);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            // Entity => DTO
            var countyDTO = Mapper.Map<CountyDTO>(entity);
            Assert.Equal(countyDTO.Id, entity.Id);
            Assert.Equal(countyDTO.Name, entity.Name);
            Assert.Equal(countyDTO.CodeIBGE, entity.CodeIBGE);
            Assert.Equal(countyDTO.UFId, entity.UFId);
            
            var countyCompleteDTO = Mapper.Map<CountyCompleteDTO>(listEntity.FirstOrDefault());
            Assert.Equal(countyCompleteDTO.Id, listEntity.FirstOrDefault().Id);
            Assert.Equal(countyCompleteDTO.Name, listEntity.FirstOrDefault().Name);
            Assert.Equal(countyCompleteDTO.CodeIBGE, listEntity.FirstOrDefault().CodeIBGE);
            Assert.Equal(countyCompleteDTO.UFId, listEntity.FirstOrDefault().UFId);
            Assert.NotNull(countyCompleteDTO.UF);

            var listDTO = Mapper.Map<List<CountyDTO>>(listEntity);
            Assert.True(listDTO.Count() == listEntity.Count());
            for (int i = 0; i < listDTO.Count(); i++)
            {
                Assert.Equal(listDTO[i].Id, listEntity[i].Id);
                Assert.Equal(listDTO[i].Name, listEntity[i].Name);
                Assert.Equal(listDTO[i].CodeIBGE, listEntity[i].CodeIBGE);
                Assert.Equal(listDTO[i].UFId, listEntity[i].UFId);
            }

            var countyCreateResultDTO = Mapper.Map<CountyCreateResultDTO>(entity);
            Assert.Equal(countyCreateResultDTO.Id, entity.Id);
            Assert.Equal(countyCreateResultDTO.Name, entity.Name);
            Assert.Equal(countyCreateResultDTO.CodeIBGE, entity.CodeIBGE);
            Assert.Equal(countyCreateResultDTO.UFId, entity.UFId);
            Assert.Equal(countyCreateResultDTO.CreateAt, entity.CreateAt);
            
            var countyUpdateResultDTO = Mapper.Map<CountyUpdateResultDTO>(entity);
            Assert.Equal(countyUpdateResultDTO.Id, entity.Id);
            Assert.Equal(countyUpdateResultDTO.Name, entity.Name);
            Assert.Equal(countyUpdateResultDTO.CodeIBGE, entity.CodeIBGE);
            Assert.Equal(countyUpdateResultDTO.UFId, entity.UFId);
            Assert.Equal(countyUpdateResultDTO.UpdateAt, entity.UpdateAt);

            // DTO => Model
            var countyModel = Mapper.Map<CountyModel>(countyDTO);
            Assert.Equal(countyModel.Id, countyDTO.Id);
            Assert.Equal(countyModel.Name, countyDTO.Name);
            Assert.Equal(countyModel.CodeIBGE, countyDTO.CodeIBGE);
            Assert.Equal(countyModel.UFId, countyDTO.UFId);

            // Model => CreateDTO
            var userCreateDTO = Mapper.Map<CountyCreateDTO>(countyModel);
            Assert.Equal(userCreateDTO.Name, countyModel.Name);
            Assert.Equal(userCreateDTO.CodeIBGE, countyModel.CodeIBGE);
            Assert.Equal(userCreateDTO.UFId, countyModel.UFId);

            var userUpdateDTO = Mapper.Map<CountyUpdateDTO>(countyModel);
            Assert.Equal(userUpdateDTO.Name, countyModel.Name);
            Assert.Equal(userUpdateDTO.CodeIBGE, countyModel.CodeIBGE);
            Assert.Equal(userUpdateDTO.UFId, countyModel.UFId);
        }
    }
}
