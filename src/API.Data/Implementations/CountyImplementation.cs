using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class CountyImplementation : BaseRepository<CountyEntity>, ICountyRepository
    {
        private DbSet<CountyEntity> _dataset;

        public CountyImplementation(MyContext context) : base(context)
        {
            _dataset = _context.Set<CountyEntity>();
        }

        public async Task<CountyEntity?> GetCompleteByIBGE(int codIBGE)
        {
            return await _dataset.Include(m => m.UF).FirstOrDefaultAsync(m => m.CodeIBGE.Equals(codIBGE));
        }

        public async Task<CountyEntity?> GetCompleteById(Guid id)
        {
            return await _dataset.Include(m => m.UF).FirstOrDefaultAsync(m => m.Id.Equals(id));
        }
    }
}
