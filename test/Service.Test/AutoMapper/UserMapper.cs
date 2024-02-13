using Domain.DTOs.User;
using Domain.Entities;
using Domain.Models;
using Faker;

namespace Service.Test.AutoMapper
{
    public class UserMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível mapear o modelos.")]
        public void MapTheModels()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Name.FullName(),
                Email = Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listEntity = new List<UserEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Name.FullName(),
                    Email = Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listEntity.Add(item);
            }

            // UserModel => Entity
            var userEntity = Mapper.Map<UserEntity>(model);
            Assert.Equal(userEntity.Id, model.Id);
            Assert.Equal(userEntity.Name, model.Name);
            Assert.Equal(userEntity.Email, model.Email);
            Assert.Equal(userEntity.CreateAt, model.CreateAt);
            Assert.Equal(userEntity.UpdateAt, model.UpdateAt);

            // Entity => DTO
            var userDTO = Mapper.Map<UserDTO>(userEntity);
            Assert.Equal(userDTO.Id, userEntity.Id);
            Assert.Equal(userDTO.Name, userEntity.Name);
            Assert.Equal(userDTO.Email, userEntity.Email);
            Assert.Equal(userDTO.CreateAt, userEntity.CreateAt);

            var listDTO = Mapper.Map<List<UserDTO>>(listEntity);
            Assert.True(listDTO.Count() == listEntity.Count());
            for (int i = 0; i < listDTO.Count(); i++)
            {
                Assert.Equal(listDTO[i].Id, listEntity[i].Id);
                Assert.Equal(listDTO[i].Name, listEntity[i].Name);
                Assert.Equal(listDTO[i].Email, listEntity[i].Email);
                Assert.Equal(listDTO[i].CreateAt, listEntity[i].CreateAt);
            }

            var userCreateResultDTO = Mapper.Map<UserCreateResultDTO>(userEntity);
            Assert.Equal(userCreateResultDTO.Id, userEntity.Id);
            Assert.Equal(userCreateResultDTO.Name, userEntity.Name);
            Assert.Equal(userCreateResultDTO.Email, userEntity.Email);
            Assert.Equal(userCreateResultDTO.CreateAt, userEntity.CreateAt);
            
            var userUpdateResultDTO = Mapper.Map<UserUpdateResultDTO>(userEntity);
            Assert.Equal(userUpdateResultDTO.Id, userEntity.Id);
            Assert.Equal(userUpdateResultDTO.Name, userEntity.Name);
            Assert.Equal(userUpdateResultDTO.Email, userEntity.Email);
            Assert.Equal(userUpdateResultDTO.UpdateAt, userEntity.UpdateAt);

            // DTO => Model
            var userModel = Mapper.Map<UserModel>(userDTO);
            Assert.Equal(userModel.Id, userDTO.Id);
            Assert.Equal(userModel.Name, userDTO.Name);
            Assert.Equal(userModel.Email, userDTO.Email);
            Assert.Equal(userModel.CreateAt, userDTO.CreateAt);

            var userCreateDTO = Mapper.Map<UserCreateDTO>(userModel);
            Assert.Equal(userCreateDTO.Name, userModel.Name);
            Assert.Equal(userCreateDTO.Email, userModel.Email);
            
            var userUpdateDTO = Mapper.Map<UserUpdateDTO>(userModel);
            Assert.Equal(userUpdateDTO.Id, userModel.Id);
            Assert.Equal(userUpdateDTO.Name, userModel.Name);
            Assert.Equal(userUpdateDTO.Email, userModel.Email);
        }
    }
}
