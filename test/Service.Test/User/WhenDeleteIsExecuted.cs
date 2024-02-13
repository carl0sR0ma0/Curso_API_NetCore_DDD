using Domain.Interfaces.Services.User;
using Moq;

namespace Service.Test.User
{
    public class WhenDeleteIsExecuted : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Delete.")]
        public async Task ExecutDeleteMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(IdUser)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var _deleted = await _service.Delete(IdUser);
            Assert.True(_deleted);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            _deleted = await _service.Delete(Guid.NewGuid());
            Assert.False(_deleted);
        }
    }
}
