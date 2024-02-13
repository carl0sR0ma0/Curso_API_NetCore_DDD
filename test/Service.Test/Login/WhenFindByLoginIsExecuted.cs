using Domain.DTOs;
using Domain.DTOs.User;
using Domain.Interfaces.Services.User;
using Faker;
using Moq;
using Newtonsoft.Json.Linq;

namespace Service.Test.Login
{
    public class WhenFindByLoginIsExecuted
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Find By Login.")]
        public async Task ExecuteFindByLoginMethod()
        {
            var email = Internet.Email();
            var name = Name.FullName();

            var _returnObject = new
            {
                authenticated = true,
                message = "Usuário logado com sucesso.",
                userName = name,
                userEmail = email,
                created = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = DateTime.UtcNow.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss"),
            };

            var loginDTO = new LoginDTO
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDTO)).ReturnsAsync(_returnObject);
            _service = _serviceMock.Object;

            var _result = await _service.FindByLogin(loginDTO);
            Assert.NotNull(_result);
        }
    }
}
