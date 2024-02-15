using Domain.DTOs.UF;
using Domain.Interfaces.Services.UF;
using Moq;

namespace Service.Test.UF
{
    public class WhenGetAllIsExecuted : UFTests
    {
        private IUFService _service;
        private Mock<IUFService> _serviceMock;

        [Fact(DisplayName = "É possível executar o Método GET ALL.")]
        public async Task ExecuteGETALLMethod()
        {
            _serviceMock = new Mock<IUFService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listUFDTO);
            _service = _serviceMock.Object;

            var _result = await _service.GetAll();
            Assert.NotNull(_result);
            Assert.True(_result.Count() == 10);

            var _listResult = new List<UFDTO>();
            _serviceMock = new Mock<IUFService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _recordEmpty = await _service.GetAll();
            Assert.Empty(_recordEmpty);
            Assert.True(_recordEmpty.Count() == 0);
        }
    }
}
