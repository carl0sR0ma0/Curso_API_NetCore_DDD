using Domain.DTOs.UF;

namespace Domain.Interfaces.Services.UF
{
    public interface IUFService
    {
        Task<UFDTO?> Get(Guid id);
        Task<IEnumerable<UFDTO?>> GetAll();
    }
}
