using Application.Controllers;
using Domain.DTOs.User;
using Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Faker;

namespace Application.Test.User.WhenRequestCreate
{
    public class ReturnBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Não é possível realizar o Created => Bad Request")]
        public async Task InvokeControllerPostBadRequest()
        {
            var serviceMock = new Mock<IUserService>(0);
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
            _controller.ModelState.AddModelError("Name", "É um Campo Obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<Object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userCreateDTO = new UserCreateDTO
            {
                Name = name,
                Email = email
            };

            var _result = await _controller.Post(userCreateDTO);
            Assert.True(_result is BadRequestObjectResult);
        }
    }
}
