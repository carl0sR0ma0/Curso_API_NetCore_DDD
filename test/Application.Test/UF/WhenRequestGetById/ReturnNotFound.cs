using Application.Controllers;
using Domain.DTOs.UF;
using Domain.Interfaces.Services.UF;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.UF.WhenRequestGetById
{
    public class ReturnNotFound
    {
        private UFsController _controller;

        [Fact(DisplayName = "Não é possível realizar o Get By Id Ok => Not Found")]
        public async Task InvokeControllerGetByIdNotFound()
        {
            var serviceMock = new Mock<IUFService>();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UFDTO)null));

            _controller = new UFsController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }
    }
}
