using Domain.DTOs;
using Domain.Interfaces.Services.User;
using Domain.Repository;

namespace Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;

        public LoginService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> FindByLogin(LoginDTO user)
        {
            if (user is not null && !string.IsNullOrEmpty(user.Email)) return await _repository.FindByLogin(user.Email);
            else return null;
        }
    }
}
