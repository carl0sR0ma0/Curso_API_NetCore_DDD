using Domain.DTOs.ZipCode;
using Domain.Interfaces.Services.ZipCode;
using Moq;

namespace Service.Test.ZipCode
{
    public class WhenGetByIdIsExecuted : ZipCodeTests
    {
        private IZipCodeService? _service;
        private Mock<IZipCodeService>? _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Get By Id.")]
        public async Task ExecuteGetByIdMethod()
        {
            _serviceMock = new Mock<IZipCodeService>();
            _serviceMock.Setup(m => m.Get(IdZipCode)).ReturnsAsync(zipCodeDTO);
            _service = _serviceMock.Object;

            var _result = await _service.Get(IdZipCode);
            Assert.NotNull(_result);
            Assert.True(_result.Id == IdZipCode);
            Assert.Equal(ZipCodeOrigin, _result.ZipCode);
            Assert.Equal(PublicPlaceOrigin, _result.PublicPlace);

            _serviceMock = new Mock<IZipCodeService>();
            _serviceMock.Setup(m => m.Get(ZipCodeOrigin)).ReturnsAsync(zipCodeDTO);
            _service = _serviceMock.Object;
            
            Assert.NotNull(_result);
            Assert.True(_result.Id == IdZipCode);
            Assert.Equal(ZipCodeOrigin, _result.ZipCode);
            Assert.Equal(PublicPlaceOrigin, _result.PublicPlace);

            _serviceMock = new Mock<IZipCodeService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((ZipCodeDTO)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Guid.NewGuid());
            Assert.Null(_record);
        }
    }
}
