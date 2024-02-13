using Domain.DTOs.User;
using Domain.Interfaces.Services.User;
using Moq;

namespace Service.Test.User
{
    public class WhenGetIsExecuted : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET BY ID.")]
        public async Task ExecuteGetByIdMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(IdUser)).ReturnsAsync(userDTO);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUser);
            Assert.NotNull(result.Id == IdUser);
            Assert.Equal(NameUser, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDTO) null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdUser);
            Assert.Null(_record);
        }
    }
}
