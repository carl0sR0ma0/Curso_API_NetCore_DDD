using Application.Controllers;
using Domain.DTOs.County;
using Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.County.WhenRequestCreate
{
    public class ReturnCreated
    {
        private CountiesController _controller;

        [Fact(DisplayName = "É possível realizar o Created")]
        public async Task InvokeControllerCreateOk()
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

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<Object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var countyCreateDTO = new CountyCreateDTO
            {
                Name = "São Paulo",
                CodeIBGE = 1
            };

            var _result = await _controller.Post(countyCreateDTO);
            Assert.True(_result is CreatedResult);
        }
    }
}
