using Domain.Interfaces.Services.User;
using Moq;

namespace Service.Test.User
{
    public class WhenPutIsExecuted : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Put.")]
        public async Task ExecutPutMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userCreateDTO)).ReturnsAsync(userCreateResultDTO);
            _service = _serviceMock.Object;

            var _result = await _service.Post(userCreateDTO);
            Assert.NotNull(_result);
            Assert.Equal(NameUser, _result.Name);
            Assert.Equal(EmailUser, _result.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(userUpdateDTO)).ReturnsAsync(userUpdateResultDTO);
            _service = _serviceMock.Object;

            var _resultUpdate = await _service.Put(userUpdateDTO);
            Assert.NotNull(_result);
            Assert.Equal(EmailUserUpdated, _resultUpdate.Email);
            Assert.Equal(NameUserUpdated, _resultUpdate.Name);
        }
    }
}
