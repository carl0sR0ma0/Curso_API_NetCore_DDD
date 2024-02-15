using Domain.Interfaces.Services.ZipCode;
using Moq;

namespace Service.Test.ZipCode
{
    public class WhenDeleteIsExecuted : ZipCodeTests
    {
        private IZipCodeService? _service;
        private Mock<IZipCodeService>? _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Delete.")]
        public async Task ExecuteDeleteMethod()
        {
            _serviceMock = new Mock<IZipCodeService>();
            _serviceMock.Setup(m => m.Delete(IdZipCode)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var _deleted = await _service.Delete(IdZipCode);
            Assert.True(_deleted);

            _serviceMock = new Mock<IZipCodeService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            _deleted = await _service.Delete(Guid.NewGuid());
            Assert.False(_deleted);
        }
    }
}
