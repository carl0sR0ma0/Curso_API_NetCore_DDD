using Application.Controllers;
using Domain.DTOs.User;
using Domain.Interfaces.Services.User;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.User.WhenRequestGetById
{
    public class ReturnOk
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possível realizar GetById com OK")]
        public async Task InvokeControllerGetByIdOK()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Name.FullName();
            var email = Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(new UserDTO
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                CreateAt = DateTime.UtcNow
            });

            _controller = new UsersController(serviceMock.Object);

            var _result = await _controller.GetById(Guid.NewGuid());
            Assert.True(_result is OkObjectResult);

            var _resultValue = ((OkObjectResult)_result).Value as UserDTO;
            Assert.NotNull(_resultValue);
            Assert.Equal(name, _resultValue.Name);
            Assert.Equal(email, _resultValue.Email);
        }
    }
}
