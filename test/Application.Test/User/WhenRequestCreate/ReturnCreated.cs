using Application.Controllers;
using Domain.DTOs.User;
using Domain.Interfaces.Services.User;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.User.WhenRequestCreate
{
    public class ReturnCreated
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possível realizar o Created")]
        public async Task InvokeControllerPostCreate()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Name.FullName();
            var email = Internet.Email();

            serviceMock.Setup(m => m.Post(It.IsAny<UserCreateDTO>())).ReturnsAsync(new UserCreateResultDTO
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                CreateAt = DateTime.UtcNow
            });

            _controller = new UsersController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<Object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userCreateDTO = new UserCreateDTO
            {
                Name = name,
                Email = email
            };

            var _result = await _controller.Post(userCreateDTO);
            Assert.True(_result is CreatedResult);

            var _resultValue = ((CreatedResult)_result).Value as UserCreateResultDTO;
            Assert.NotNull(_resultValue);
            Assert.Equal(userCreateDTO.Name, _resultValue.Name);
            Assert.Equal(userCreateDTO.Email, _resultValue.Email);
        }
    }
}
