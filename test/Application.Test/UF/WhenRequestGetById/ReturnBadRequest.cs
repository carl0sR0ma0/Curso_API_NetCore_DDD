using Application.Controllers;
using Domain.DTOs.UF;
using Domain.Interfaces.Services.UF;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.UF.WhenRequestGetById
{
    public class ReturnBadRequest
    {
        private UFsController _controller;

        [Fact(DisplayName = "Não é possível realizar o Get By Id Ok => Bad Request")]
        public async Task InvokeControllerGetByIdBadRequest()
        {
            var serviceMock = new Mock<IUFService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UFDTO
                {
                    Id = Guid.NewGuid(),
                    Name = "São Paulo",
                    Initials = "SP"
                }
            );

            _controller = new UFsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
