using AutoMapper;
using Domain.DTOs.County;
using Domain.DTOs.ZipCode;
using Domain.Entities;
using Domain.Interfaces.Services.ZipCode;
using Domain.Models;
using Domain.Repository;
using System.Diagnostics.Metrics;

namespace Service.Services
{
    public class ZipCodeService : IZipCodeService
    {
        private IZipCodeRepository _repository;
        private readonly IMapper _mapper;

        public ZipCodeService(IZipCodeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ZipCodeDTO> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ZipCodeDTO>(entity);
        }

        public async Task<ZipCodeDTO> Get(string zipCode)
        {
            var entity = await _repository.SelectAsync(zipCode);
            return _mapper.Map<ZipCodeDTO>(entity);
        }

        public async Task<ZipCodeCreateResultDTO> Post(ZipCodeCreateDTO zipCode)
        {
            var model = _mapper.Map<ZipCodeModel>(zipCode);
            var entity = _mapper.Map<ZipCodeEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<ZipCodeCreateResultDTO>(result);
        }

        public async Task<ZipCodeUpdateResultDTO> Put(ZipCodeUpdateDTO zipCode)
        {
            var model = _mapper.Map<ZipCodeModel>(zipCode);
            var entity = _mapper.Map<ZipCodeEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<ZipCodeUpdateResultDTO>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
