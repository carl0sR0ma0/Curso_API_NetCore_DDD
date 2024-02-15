using Domain.DTOs.ZipCode;

namespace Domain.Interfaces.Services.ZipCode
{
    public interface ICepService
    {
        Task<ZipCodeDTO> Get(Guid id);
        Task<ZipCodeDTO> Get(string cep);
        Task<ZipCodeCreateResultDTO> Post(ZipCodeCreateDTO cep);
        Task<ZipCodeUpdateResultDTO> Put(ZipCodeUpdateDTO cep);
        Task<bool> Delete(Guid id);
    }
}
