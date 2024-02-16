using Application.Controllers;
using Domain.DTOs.County;
using Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.County.WhenRequestCreate
{
    public class ReturnBadRequest
    {
        private CountiesController _controller;

        [Fact(DisplayName = "Não é possível realizar o Created => Bad Request")]
        public async Task InvokeControllerCreateBadRequest()
        {
            var serviceMock = new Mock<ICountyService>();
            serviceMock.Setup(m => m.Post(It.IsAny<CountyCreateDTO>())).ReturnsAsync(
                new CountyCreateResultDTO
                {
                    Id = Guid.NewGuid(),
                    Name = "São Paulo",
                    CreateAt = DateTime.Now
                }
            );

            _controller = new CountiesController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<Object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var countyCreateDTO = new CountyCreateDTO
            {
                Name = "São Paulo",
                CodeIBGE = 1
            };

            var _result = await _controller.Post(countyCreateDTO);
            Assert.True(_result is BadRequestObjectResult);
        }
    }
}
