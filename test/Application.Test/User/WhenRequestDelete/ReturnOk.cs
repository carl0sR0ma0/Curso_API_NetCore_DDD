using Application.Controllers;
using Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.User.WhenRequestDelete
{
    public class ReturnOk
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possível realizar Delete com o OK")]
        public async Task InvokeControllerDeleteOK()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);

            var _result = await _controller.Delete(Guid.NewGuid());
            Assert.True(_result is OkObjectResult);

            var _resultValue = ((OkObjectResult)_result).Value;
            Assert.NotNull(_resultValue);
            Assert.True((bool)_resultValue);
        }
    }
}
