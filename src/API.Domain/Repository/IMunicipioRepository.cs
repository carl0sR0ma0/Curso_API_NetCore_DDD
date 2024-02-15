using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Repository
{
    public interface IMunicipioRepository : IRepository<MunicipioEntity>
    {
        Task<MunicipioEntity?> GetCompleteById(Guid id);
        Task<MunicipioEntity?> GetCompleteByIBGE(int codIBGE);
    }
}
