using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class ZipCodeImplementation : BaseRepository<ZipCodeEntity>, IZipCodeRepository
    {
        private DbSet<ZipCodeEntity> _dataset;

        public ZipCodeImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ZipCodeEntity>();
        }

        public async Task<ZipCodeEntity?> SelectAsync(string cep)
        {
            return await _dataset.Include(c => c.County).ThenInclude(m => m.UF).SingleOrDefaultAsync(c => c.ZipCode.Equals(cep));
        }
    }
}
