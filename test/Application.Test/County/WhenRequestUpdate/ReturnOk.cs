using Application.Controllers;
using Domain.DTOs.County;
using Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.County.WhenRequestUpdate
{
    public class ReturnOk
    {
        private CountiesController _controller;

        [Fact(DisplayName = "É possível realizar o Ok")]
        public async Task InvokeControllerUpdatedOk()
        {
            var serviceMock = new Mock<ICountyService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CountyUpdateDTO>())).ReturnsAsync(
                new CountyUpdateResultDTO
                {
                    Id = Guid.NewGuid(),
                    Name = "São Paulo",
                    UpdateAt = DateTime.Now
                }
            );

            _controller = new CountiesController(serviceMock.Object);

            var countyUpdateDTO = new CountyUpdateDTO
            {
                Name = "São Paulo",
                CodeIBGE = 1
            };

            var _result = await _controller.Put(countyUpdateDTO);
            Assert.True(_result is OkObjectResult);
        }
    }
}
