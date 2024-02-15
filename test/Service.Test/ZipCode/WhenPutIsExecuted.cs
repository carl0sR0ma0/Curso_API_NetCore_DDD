using Domain.Interfaces.Services.ZipCode;
using Moq;

namespace Service.Test.ZipCode
{
    public class WhenPutIsExecuted : ZipCodeTests
    {
        private IZipCodeService? _service;
        private Mock<IZipCodeService>? _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Put.")]
        public async Task ExecutePutMethod()
        {
            _serviceMock = new Mock<IZipCodeService>();
            _serviceMock.Setup(m => m.Put(zipCodeUpdateDTO)).ReturnsAsync(zipCodeUpdateResultDTO);
            _service = _serviceMock.Object;

            var _result = await _service.Put(zipCodeUpdateDTO);
            Assert.NotNull(_result);
            Assert.Equal(ZipCodeUpdated, _result.ZipCode);
            Assert.Equal(PublicPlaceUpdated, _result.PublicPlace);
            Assert.Equal(NumberUpdated, _result.Number);
        }
    }
}
