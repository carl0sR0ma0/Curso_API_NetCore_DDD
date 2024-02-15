using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class UFImplementation : BaseRepository<UFEntity>, IUFRepository
    {
        private DbSet<UFEntity> _dataset;

        public UFImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UFEntity>();
        }
    }
}
