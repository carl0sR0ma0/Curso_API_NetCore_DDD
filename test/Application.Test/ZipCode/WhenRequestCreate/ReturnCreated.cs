using Application.Controllers;
using Domain.DTOs.ZipCode;
using Domain.Interfaces.Services.ZipCode;
using Faker;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Application.Test.ZipCode.WhenRequestCreate
{
    public class ReturnCreated
    {
        private ZipCodesController _controller;

        [Fact(DisplayName = "É possível realizar o Created")]
        public async Task InvokeControllerCreateOk()
        {
            var serviceMock = new Mock<IZipCodeService>();
            serviceMock.Setup(m => m.Post(It.IsAny<ZipCodeCreateDTO>())).ReturnsAsync(
                new ZipCodeCreateResultDTO
                {
                    Id = Guid.NewGuid(),
                    PublicPlace = Address.StreetName(),
                    CreateAt = DateTime.Now
                }
            );

            _controller = new ZipCodesController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<Object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var zipCodeCreateDTO = new ZipCodeCreateDTO
            {
                PublicPlace = Address.StreetName(),
                Number = ""
            };

            var _result = await _controller.Post(zipCodeCreateDTO);
            Assert.True(_result is CreatedResult);
        }
    }
}
