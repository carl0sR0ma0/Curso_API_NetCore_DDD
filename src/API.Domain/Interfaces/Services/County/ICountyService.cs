﻿using Domain.DTOs.County;

namespace Domain.Interfaces.Services.County
{
    public interface ICountyService
    {
        Task<CountyDTO> Get(Guid id);
        Task<CountyCompleteDTO> GetCompleteById(Guid id);
        Task<CountyCompleteDTO> GetCompleteByIBGE(int codIBGE);
        Task<IEnumerable<CountyCompleteDTO>> GetAll();
        Task<CountyCreateResultDTO> Post(CountyCreateDTO municipio);
        Task<CountyUpdateResultDTO> Put(CountyUpdateDTO municipio);
        Task<bool> Delete(Guid id);
    }
}
