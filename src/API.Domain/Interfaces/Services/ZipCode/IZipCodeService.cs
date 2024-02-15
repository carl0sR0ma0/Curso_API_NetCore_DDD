using Domain.DTOs.ZipCode;

namespace Domain.Interfaces.Services.ZipCode
{
    public interface IZipCodeService
    {
        Task<ZipCodeDTO> Get(Guid id);
        Task<ZipCodeDTO> Get(string zipCode);
        Task<ZipCodeCreateResultDTO> Post(ZipCodeCreateDTO zipCode);
        Task<ZipCodeUpdateResultDTO> Put(ZipCodeUpdateDTO zipCode);
        Task<bool> Delete(Guid id);
    }
}
