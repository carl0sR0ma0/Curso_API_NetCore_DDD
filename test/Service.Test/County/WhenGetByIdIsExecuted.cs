using Domain.DTOs.County;
using Domain.Interfaces.Services.County;
using Moq;

namespace Service.Test.County
{
    public class WhenGetByIdIsExecuted : CountyTests
    {
        private ICountyService _service;
        private Mock<ICountyService> _serviceMock;

        [Fact(DisplayName = "É possível executar o Método GET By Id.")]
        public async Task ExecuteGETByIdMethod()
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Get(IdCounty)).ReturnsAsync(countyDTO);
            _service = _serviceMock.Object;

            var _result = await _service.Get(IdCounty);
            Assert.NotNull(_result);
            Assert.True(_result.Id == IdCounty);
            Assert.Equal(NameCounty, _result.Name);
            Assert.Equal(CodeIBGECounty, _result.CodeIBGE);

            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CountyDTO)null));
            _service = _serviceMock.Object;

            var _recordNull = await _service.Get(IdCounty);
            Assert.Null(_recordNull);
        }
    }
}
