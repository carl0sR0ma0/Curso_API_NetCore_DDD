using Application.Controllers;
using Domain.DTOs.County;
using Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.County.WhenRequestGetCompleteById
{
    public class ReturnNotFound
    {
        private CountiesController _controller;

        [Fact(DisplayName = "Não é possível realizar o Ok => Not Found")]
        public async Task InvokeControllerGetCompleteByIdNotFound()
        {
            var serviceMock = new Mock<ICountyService>();
            serviceMock.Setup(m => m.GetCompleteById(It.IsAny<Guid>())).Returns(Task.FromResult((CountyCompleteDTO)null));

            _controller = new CountiesController(serviceMock.Object);

            var _result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(_result is NotFoundResult);
        }
    }
}
