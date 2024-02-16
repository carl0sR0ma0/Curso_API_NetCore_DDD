using Application.Controllers;
using Domain.Interfaces.Services.ZipCode;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.ZipCode.WhenRequestDelete
{
    public class ReturnOk
    {
        private ZipCodesController _controller;

        [Fact(DisplayName = "Épossível realizar o Ok")]
        public async Task InvokeControllerDeleteOk()
        {
            var serviceMock = new Mock<IZipCodeService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new ZipCodesController(serviceMock.Object);

            var _result = await _controller.Delete(Guid.NewGuid());
            Assert.True(_result is OkObjectResult);
        }
    }
}
