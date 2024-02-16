using Application.Controllers;
using Domain.DTOs.County;
using Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.County.WhenRequestGetById
{
    public class ReturnNotFound
    {
        private CountiesController _controller;

        [Fact(DisplayName = "Não é possível realizar o Ok => Not Found")]
        public async Task InvokeControllerGetByIdNotFound()
        {
            var serviceMock = new Mock<ICountyService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CountyDTO)null));

            _controller = new CountiesController(serviceMock.Object);

            var _result = await _controller.Get(Guid.NewGuid());
            Assert.True(_result is NotFoundResult);
        }
    }
}
