using Domain.DTOs.County;
using Domain.Interfaces.Services.County;
using Moq;

namespace Service.Test.County
{
    public class WhenGetAllIsExecuted : CountyTests
    {
        private ICountyService _service;
        private Mock<ICountyService> _serviceMock;

        [Fact(DisplayName = "É possível executar o Método GET ALL.")]
        public async Task ExecuteGETALLMethod()
        {
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listDTO);
            _service = _serviceMock.Object;

            var _result = await _service.GetAll();
            Assert.NotNull(_result);
            Assert.True(_result.Count() == 10);

            var _listResult = new List<CountyDTO>();
            _serviceMock = new Mock<ICountyService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
