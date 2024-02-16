using Application.Controllers;
using Domain.DTOs.County;
using Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.County.WhenRequestGetAll
{
    public class ReturnBadRequest
    {
        private CountiesController _controller;

        [Fact(DisplayName = "Não é possível realizar o Ok => Bad Request")]
        public async Task InvokeControllerGetAllBadRequest()
        {
            var serviceMock = new Mock<ICountyService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<CountyDTO>
                {
                    new CountyDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = "São Paulo"
                    },
                    new CountyDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = "Limeira"
                    }
                }
            );

            _controller = new CountiesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Campo inválido");

            var _result = await _controller.GetAll();
            Assert.True(_result is BadRequestObjectResult);
        }
    }
}
