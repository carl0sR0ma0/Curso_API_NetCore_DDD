using Application.Controllers;
using Domain.DTOs.ZipCode;
using Domain.Interfaces.Services.ZipCode;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.ZipCode.WhenRequestUpdate
{
    public class ReturnOk
    {
        private ZipCodesController _controller;

        [Fact(DisplayName = "É possível realizar o Ok")]
        public async Task InvokeControllerUpdatedOk()
        {
            var serviceMock = new Mock<IZipCodeService>();
            serviceMock.Setup(m => m.Put(It.IsAny<ZipCodeUpdateDTO>())).ReturnsAsync(
                new ZipCodeUpdateResultDTO
                {
                    Id = Guid.NewGuid(),
                    PublicPlace = Address.StreetName(),
                    UpdateAt = DateTime.Now
                }
            );

            _controller = new ZipCodesController(serviceMock.Object);

            var zipCodeUpdateDTO = new ZipCodeUpdateDTO
            {
                PublicPlace = Address.StreetName(),
                ZipCode = "13480000"
            };

            var _result = await _controller.Put(zipCodeUpdateDTO);
            Assert.True(_result is OkObjectResult);
        }
    }
}
