using Domain.Interfaces.Services.ZipCode;
using Moq;

namespace Service.Test.ZipCode
{
    public class WhenCreateIsExecuted : ZipCodeTests
    {
        private IZipCodeService? _service;
        private Mock<IZipCodeService>? _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Create.")]
        public async Task ExecuteCreateMethod()
        {
            _serviceMock = new Mock<IZipCodeService>();
            _serviceMock.Setup(m => m.Post(zipCodeCreateDTO)).ReturnsAsync(zipCodeCreateResultDTO);
            _service = _serviceMock.Object;

            var _result = await _service.Post(zipCodeCreateDTO);
            Assert.NotNull(_result);
            Assert.Equal(ZipCodeOrigin, _result.ZipCode);
            Assert.Equal(PublicPlaceOrigin, _result.PublicPlace);
            Assert.Equal(NumberOrigin, _result.Number);
        }
    }
}
