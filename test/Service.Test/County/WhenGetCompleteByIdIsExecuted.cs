using Domain.Interfaces.Services.County;
using Moq;

namespace Service.Test.County
{
    public class WhenGetCompleteByIdIsExecuted : CountyTests
    {
        private ICountyService _service;
        private Mock<ICountyService> _serviceMock;

        [Fact(DisplayName = "É possível executar o Método GET Complete By Id.")]
        public async Task ExecuteGETCompleteByCodeIdMethod()
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.GetCompleteById(IdCounty)).ReturnsAsync(countyCompleteDTO);
            _service = _serviceMock.Object;

            var _result = await _service.GetCompleteById(IdCounty);
            Assert.NotNull(_result);
            Assert.True(_result.Id == IdCounty);
            Assert.Equal(NameCounty, _result.Name);
            Assert.Equal(CodeIBGECounty, _result.CodeIBGE);
            Assert.NotNull(_result.UF);
        }
    }
}
