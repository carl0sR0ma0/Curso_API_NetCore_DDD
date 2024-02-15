using Domain.DTOs.County;

namespace Domain.Interfaces.Services.County
{
    public interface ICountyService
    {
        Task<CountyDTO> Get(Guid id);
        Task<CountyCompleteDTO> GetCompleteById(Guid id);
        Task<CountyCompleteDTO> GetCompleteByIBGE(int codIBGE);
        Task<IEnumerable<CountyDTO>> GetAll();
        Task<CountyCreateResultDTO> Post(CountyCreateDTO county);
        Task<CountyUpdateResultDTO> Put(CountyUpdateDTO county);
        Task<bool> Delete(Guid id);
    }
}
