using Domain.Interfaces.Services.County;
using Moq;

namespace Service.Test.County
{
    public class WhenGetCompleteByIBGEIsExecuted : CountyTests
    {
        private ICountyService _service;
        private Mock<ICountyService> _serviceMock;

        [Fact(DisplayName = "É possível executar o Método GET Complete By CodeIBGE.")]
        public async Task ExecuteGETCompleteByCodeIBGEMethod()
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.GetCompleteByIBGE(CodeIBGECounty)).ReturnsAsync(countyCompleteDTO);
            _service = _serviceMock.Object;

            var _result = await _service.GetCompleteByIBGE(CodeIBGECounty);
            Assert.NotNull(_result);
            Assert.True(_result.Id == IdCounty);
            Assert.Equal(NameCounty, _result.Name);
            Assert.Equal(CodeIBGECounty, _result.CodeIBGE);
            Assert.NotNull(_result.UF);
        }
    }
}
