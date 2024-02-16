using Application.Controllers;
using Domain.DTOs.ZipCode;
using Domain.Interfaces.Services.ZipCode;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.ZipCode.WhenRequestGetById
{
    public class ReturnNotFound
    {
        private ZipCodesController _controller;

        [Fact(DisplayName = "Não é possível realizar o Ok => Not Found")]
        public async Task InvokeControllerGetByIdNotFound()
        {
            var serviceMock = new Mock<IZipCodeService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((ZipCodeDTO)null));

            _controller = new ZipCodesController(serviceMock.Object);

            var _result = await _controller.Get(Guid.NewGuid());
            Assert.True(_result is NotFoundResult);
        }
    }
}
