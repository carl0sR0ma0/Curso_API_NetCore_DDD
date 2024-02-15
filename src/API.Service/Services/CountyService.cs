using AutoMapper;
using Domain.DTOs.County;
using Domain.Entities;
using Domain.Interfaces.Services.County;
using Domain.Models;
using Domain.Repository;

namespace Service.Services
{
    public class CountyService : ICountyService
    {
        private ICountyRepository _repository;
        private readonly IMapper _mapper;

        public CountyService(ICountyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CountyDTO> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CountyDTO>(entity);
        }

        public async Task<CountyCompleteDTO> GetCompleteById(Guid id)
        {
            var entity = await _repository.GetCompleteById(id);
            return _mapper.Map<CountyCompleteDTO>(entity);
        }

        public async Task<CountyCompleteDTO> GetCompleteByIBGE(int codIBGE)
        {
            var entity = await _repository.GetCompleteByIBGE(codIBGE);
            return _mapper.Map<CountyCompleteDTO>(entity);
        }

        public async Task<IEnumerable<CountyDTO>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<CountyDTO>>(listEntity);
        }

        public async Task<CountyCreateResultDTO> Post(CountyCreateDTO county)
        {
            var model = _mapper.Map<CountyModel>(county);
            var entity = _mapper.Map<CountyEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<CountyCreateResultDTO>(result);
        }

        public async Task<CountyUpdateResultDTO> Put(CountyUpdateDTO county)
        {
            var model = _mapper.Map<CountyModel>(county);
            var entity = _mapper.Map<CountyEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<CountyUpdateResultDTO>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
