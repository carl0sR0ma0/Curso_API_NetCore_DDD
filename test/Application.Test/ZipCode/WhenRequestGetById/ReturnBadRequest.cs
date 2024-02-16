using Application.Controllers;
using Domain.DTOs.ZipCode;
using Domain.Interfaces.Services.ZipCode;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.ZipCode.WhenRequestGetById
{
    public class ReturnBadRequest
    {
        private ZipCodesController _controller;

        [Fact(DisplayName = "Não é possível realizar o Ok => Bad Request")]
        public async Task InvokeControllerGetByIdBadRequest()
        {
            var serviceMock = new Mock<IZipCodeService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new ZipCodeDTO
                {
                    Id = Guid.NewGuid(),
                    PublicPlace = Address.StreetName()
                }
            );

            _controller = new ZipCodesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Campo inválido");

            var _result = await _controller.Get(Guid.NewGuid());
            Assert.True(_result is BadRequestObjectResult);
        }
    }
}
