using Domain.DTOs.User;

namespace Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDTO> Get(Guid id);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserCreateResultDTO> Post(UserCreateDTO user);
        Task<UserUpdateResultDTO> Put(UserUpdateDTO user);
        Task<bool> Delete(Guid id);
    }
}
