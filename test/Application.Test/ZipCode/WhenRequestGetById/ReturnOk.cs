using Application.Controllers;
using Domain.DTOs.ZipCode;
using Domain.Interfaces.Services.ZipCode;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.ZipCode.WhenRequestGetById
{
    public class ReturnOk
    {
        private ZipCodesController _controller;

        [Fact(DisplayName = "É possível realizar o Ok")]
        public async Task InvokeControllerGetByIdOk()
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

            var _result = await _controller.Get(Guid.NewGuid());
            Assert.True(_result is OkObjectResult);
        }
    }
}
