using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Repository
{
    public interface IZipCodeRepository : IRepository<ZipCodeEntity>
    {
        Task<ZipCodeEntity?> SelectAsync(string cep);
    }
}
