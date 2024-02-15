using Domain.Interfaces.Services.County;
using Moq;

namespace Service.Test.County
{
    public class WhenDeleteIsExecuted : CountyTests
    {
        private ICountyService _service;
        private Mock<ICountyService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Delete.")]
        public async Task ExecuteDeleteMethod()
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Delete(IdCounty)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var _deleted = await _service.Delete(IdCounty);
            Assert.True(_deleted);

            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            _deleted = await _service.Delete(Guid.NewGuid());
            Assert.False(_deleted);
        }
    }
}
