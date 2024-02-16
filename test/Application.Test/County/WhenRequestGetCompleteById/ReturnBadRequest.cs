using Application.Controllers;
using Domain.DTOs.County;
using Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.County.WhenRequestGetCompleteById
{
    public class ReturnBadRequest
    {
        private CountiesController _controller;

        [Fact(DisplayName = "Não é possível realizar o Ok => Bad Request")]
        public async Task InvokeControllerGetCompleteByIdBadRequest()
        {
            var serviceMock = new Mock<ICountyService>();
            serviceMock.Setup(m => m.GetCompleteById(It.IsAny<Guid>())).ReturnsAsync(
                new CountyCompleteDTO
                {
                    Id = Guid.NewGuid(),
                    Name = "São Paulo"
                }
            );

            _controller = new CountiesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Campo inválido");

            var _result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(_result is BadRequestObjectResult);
        }
    }
}
