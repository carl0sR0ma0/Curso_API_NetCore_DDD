using Application.Controllers;
using Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.County.WhenRequestDelete
{
    public class ReturnOk
    {
        private CountiesController _controller;

        [Fact(DisplayName = "Épossível realizar o Ok")]
        public async Task InvokeControllerDeleteOk()
        {
            var serviceMock = new Mock<ICountyService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new CountiesController(serviceMock.Object);

            var _result = await _controller.Delete(Guid.NewGuid());
            Assert.True(_result is OkObjectResult);
        }
    }
}
