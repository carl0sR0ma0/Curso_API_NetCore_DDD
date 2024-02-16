using Application.Controllers;
using Domain.DTOs.UF;
using Domain.Interfaces.Services.UF;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.UF.WhenRequestGetById
{
    public class ReturnOk
    {
        private UFsController _controller;

        [Fact(DisplayName = "É possível realizar o Get By Id Ok")]
        public async Task InvokeControllerGetByIdOk()
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

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }
    }
}
