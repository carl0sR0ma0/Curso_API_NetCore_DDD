using Domain.DTOs.UF;
using Domain.Interfaces.Services.UF;
using Moq;

namespace Service.Test.UF
{
    public class WhenGetAByIdIsExecuted : UFTests
    {
        private IUFService _service;
        private Mock<IUFService> _serviceMock;

        [Fact(DisplayName = "É possível executar o Método GET By Id.")]
        public async Task ExecuteGETByIdMethod()
        {
            _serviceMock = new Mock<IUFService>();
            _serviceMock.Setup(m => m.Get(IDUF)).ReturnsAsync(UFDTO);
            _service = _serviceMock.Object;

            var _result = await _service.Get(IDUF);
            Assert.NotNull(_result);
            Assert.True(_result.Id == IDUF);
            Assert.Equal(Name, _result.Name);

            _serviceMock = new Mock<IUFService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UFDTO)null));
            _service = _serviceMock.Object;

            var _recordNull = await _service.Get(IDUF);
            Assert.Null(_recordNull);
        }
    }
}
