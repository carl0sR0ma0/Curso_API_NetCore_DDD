using Application.Controllers;
using Domain.DTOs.User;
using Domain.Interfaces.Services.User;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.User.WhenRequestGetAll
{
    public class ReturnBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Não é possível realizar o Get All Ok => Bad Request")]
        public async Task InvokeControllerGetAllBadRequest()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(new List<UserDTO>()
            {
                new UserDTO
                {
                    Id = Guid.NewGuid(),
                    Name = Name.FullName(),
                    Email = Internet.Email(),
                    CreateAt = DateTime.UtcNow
                },
                new UserDTO
                {
                    Id = Guid.NewGuid(),
                    Name = Name.FullName(),
                    Email = Internet.Email(),
                    CreateAt = DateTime.UtcNow
                }
            });

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var _result = await _controller.GetAll();
            Assert.True(_result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
