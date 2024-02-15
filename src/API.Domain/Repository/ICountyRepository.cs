using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Repository
{
    public interface ICountyRepository : IRepository<CountyEntity>
    {
        Task<CountyEntity?> GetCompleteById(Guid id);
        Task<CountyEntity?> GetCompleteByIBGE(int codIBGE);
    }
}
