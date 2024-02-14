using Application.Controllers;
using Domain.DTOs.User;
using Domain.Interfaces.Services.User;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.User.WhenRequestUpdate
{
    public class ReturnBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Não é possível realizar Put com OK => Bad Request")]
        public async Task InvokeControllerPutBadRequest()
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
            _controller.ModelState.AddModelError("Email", "É um campo obrigatório");

            var userUpdateDTO = new UserUpdateDTO
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            };

            var _result = await _controller.Put(userUpdateDTO);
            Assert.True(_result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
