using Application.Controllers;
using Domain.DTOs.County;
using Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.County.WhenRequestGetCompleteByIBGE
{
    public class ReturnOk
    {
        private CountiesController _controller;

        [Fact(DisplayName = "É possível realizar o Ok")]
        public async Task InvokeControllerGetCompleteByIBGEOk()
        {
            var serviceMock = new Mock<ICountyService>();
            serviceMock.Setup(m => m.GetCompleteByIBGE(It.IsAny<int>())).ReturnsAsync(
                new CountyCompleteDTO
                {
                    Id = Guid.NewGuid(),
                    Name = "São Paulo"
                }
            );

            _controller = new CountiesController(serviceMock.Object);

            var _result = await _controller.GetCompleteByIBGE(1);
            Assert.True(_result is OkObjectResult);
        }
    }
}
