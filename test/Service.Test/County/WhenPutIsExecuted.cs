using Domain.Interfaces.Services.County;
using Moq;

namespace Service.Test.County
{
    public class WhenPutIsExecuted : CountyTests
    {
        private ICountyService? _service;
        private Mock<ICountyService>? _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Put.")]
        public async Task ExecutePutMethod()
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Put(countyUpdateDTO)).ReturnsAsync(countyUpdateResultDTO);
            _service = _serviceMock.Object;

            var _resultUpdate = await _service.Put(countyUpdateDTO);
            Assert.NotNull(_resultUpdate);
            Assert.Equal(NameUpdateCounty, _resultUpdate.Name);
            Assert.Equal(CodeIBGEUpdateCounty, _resultUpdate.CodeIBGE);
            Assert.Equal(IdUF, _resultUpdate.UFId);
        }
    }
}
