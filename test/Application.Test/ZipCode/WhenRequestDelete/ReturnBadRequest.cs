using Application.Controllers;
using Domain.Interfaces.Services.ZipCode;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.ZipCode.WhenRequestDelete
{
    public class ReturnBadRequest
    {
        private ZipCodesController _controller;

        [Fact(DisplayName = "Não é possível realizar o Ok => Bad Request")]
        public async Task InvokeControllerDeleteBadRequest()
        {
            var serviceMock = new Mock<IZipCodeService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new ZipCodesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Campo inválido");

            var _result = await _controller.Delete(Guid.NewGuid());
            Assert.True(_result is BadRequestObjectResult);
        }
    }
}
