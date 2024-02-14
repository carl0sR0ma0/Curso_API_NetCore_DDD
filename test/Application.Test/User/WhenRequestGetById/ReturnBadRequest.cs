using Application.Controllers;
using Domain.DTOs.User;
using Domain.Interfaces.Services.User;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.User.WhenRequestGetById
{
    public class ReturnBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Não é possível realizar o GetById com Ok => Bad Request")]
        public async Task InvokeControllerGetByIdBadRequest()
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
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var _result = await _controller.GetById(Guid.NewGuid());
            Assert.True(_result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
