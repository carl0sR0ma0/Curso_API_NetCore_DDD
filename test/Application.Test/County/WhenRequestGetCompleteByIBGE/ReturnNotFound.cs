using Application.Controllers;
using Domain.DTOs.County;
using Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.County.WhenRequestGetCompleteByIBGE
{
    public class ReturnNotFound
    {
        private CountiesController _controller;

        [Fact(DisplayName = "Não é possível realizar o Ok => Not Found")]
        public async Task InvokeControllerGetCompleteByIBGENotFound()
        {
            var serviceMock = new Mock<ICountyService>();
            serviceMock.Setup(m => m.GetCompleteByIBGE(It.IsAny<int>())).Returns(Task.FromResult((CountyCompleteDTO)null));

            _controller = new CountiesController(serviceMock.Object);

            var _result = await _controller.GetCompleteByIBGE(1);
            Assert.True(_result is NotFoundResult);
        }
    }
}
