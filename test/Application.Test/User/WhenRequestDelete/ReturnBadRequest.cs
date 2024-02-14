using Application.Controllers;
using Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.User.WhenRequestDelete
{
    public class ReturnBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Não possível realizar Delete com Ok => Bad Request")]
        public async Task InvokeControllerDeleteBadRequest()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var _result = await _controller.Delete(default(Guid));
            Assert.True(_result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
