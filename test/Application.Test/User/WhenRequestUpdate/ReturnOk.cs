using Application.Controllers;
using Domain.DTOs.User;
using Domain.Interfaces.Services.User;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.User.WhenRequestUpdate
{
    public class ReturnOk
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possível realizar Put com o OK")]
        public async Task InvokeControllerPutOK()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Name.FullName();
            var email = Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<UserUpdateDTO>())).ReturnsAsync(new UserUpdateResultDTO
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                UpdateAt = DateTime.UtcNow
            });

            _controller = new UsersController(serviceMock.Object);

            var userUpdateDTO = new UserUpdateDTO
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            };

            var _result = await _controller.Put(userUpdateDTO);
            Assert.True(_result is OkObjectResult);

            var _resultValue = ((OkObjectResult)_result).Value as UserUpdateResultDTO;
            Assert.NotNull(_resultValue);
            Assert.Equal(userUpdateDTO.Name, _resultValue.Name);
            Assert.Equal(userUpdateDTO.Email, _resultValue.Email);
        }
    }
}
