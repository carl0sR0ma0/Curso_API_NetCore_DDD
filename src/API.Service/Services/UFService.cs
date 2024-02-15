using AutoMapper;
using Domain.DTOs.UF;
using Domain.Interfaces.Services.UF;
using Domain.Repository;

namespace Service.Services
{
    public class UFService : IUFService
    {
        private IUFRepository _repository;
        private readonly IMapper _mapper;

        public UFService(IUFRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UFDTO?> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UFDTO?>(entity);
        }

        public async Task<IEnumerable<UFDTO?>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UFDTO?>>(listEntity);
        }
    }
}
