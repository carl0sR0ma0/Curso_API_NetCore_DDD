using Domain.DTOs.UF;
using Domain.Entities;
using Domain.Models;
using Faker;

namespace Service.Test.AutoMapper
{
    public class UFMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível mapear o modelos de UF.")]
        public void MapTheModelsToUF()
        {
            var model = new UFModel
            {
                Id = Guid.NewGuid(),
                Name = Address.UsState(),
                Initials = Address.UsState().Substring(1, 3),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            var listEntity = new List<UFEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new UFEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Address.UsState(),
                    Initials = Address.UsState().Substring(1, 3),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };
                listEntity.Add(item);
            }

            // Model => Entity
            var entity = Mapper.Map<UFEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Initials, model.Initials);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            // Entity => DTO
            var ufDTO = Mapper.Map<UFDTO>(entity);
            Assert.Equal(ufDTO.Id, entity.Id);
            Assert.Equal(ufDTO.Name, entity.Name);
            Assert.Equal(ufDTO.Initials, entity.Initials);

            var listDTO = Mapper.Map<List<UFDTO>>(listEntity);
            Assert.True(listDTO.Count() == listEntity.Count());
            for (int i = 0; i < listDTO.Count(); i++)
            {
                Assert.Equal(listDTO[i].Id, listEntity[i].Id);
                Assert.Equal(listDTO[i].Name, listEntity[i].Name);
                Assert.Equal(listDTO[i].Initials, listEntity[i].Initials);
            }

            // DTO => Model
            var ufModel = Mapper.Map<UFModel>(ufDTO);
            Assert.Equal(ufModel.Id, ufDTO.Id);
            Assert.Equal(ufModel.Name, ufDTO.Name);
            Assert.Equal(ufModel.Initials, ufDTO.Initials);
        }
    }
}
