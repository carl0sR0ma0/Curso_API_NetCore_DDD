using Domain.Interfaces.Services.County;
using Moq;

namespace Service.Test.County
{
    public class WhenCreateIsExecuted : CountyTests
    {
        private ICountyService? _service;
        private Mock<ICountyService>? _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Create.")]
        public async Task ExecuteCreateMethod()
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Post(countyCreateDTO)).ReturnsAsync(countyCreateResultDTO);
            _service = _serviceMock.Object;

            var _result = await _service.Post(countyCreateDTO);
            Assert.NotNull(_result);
            Assert.Equal(NameCounty, _result.Name);
            Assert.Equal(CodeIBGECounty, _result.CodeIBGE);
            Assert.Equal(IdUF, _result.UFId);
        }
    }
}
