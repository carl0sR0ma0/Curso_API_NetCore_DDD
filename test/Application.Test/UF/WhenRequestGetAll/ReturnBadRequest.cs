using Application.Controllers;
using Domain.DTOs.UF;
using Domain.Interfaces.Services.UF;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.UF.WhenRequestGetAll
{
    public class ReturnBadRequest
    {
        private UFsController _controller;

        [Fact(DisplayName = "Não é possível realizar o Get All Ok => Bad Request")]
        public async Task InvokeControllerGetAllBadRequest()
        {
            var serviceMock = new Mock<IUFService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UFDTO>
                {
                    new UFDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = "São Paulo",
                        Initials = "SP"
                    },
                    new UFDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = "Amazonas",
                        Initials = "AM"
                    }
                }
            );

            _controller = new UFsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
