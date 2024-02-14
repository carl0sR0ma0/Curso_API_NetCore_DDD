﻿using Domain.DTOs.CEP;

namespace Domain.Interfaces.Services.CEP
{
    public interface ICepService
    {
        Task<CepDTO> Get(Guid id);
        Task<CepDTO> Get(string cep);
        Task<CepCreateResultDTO> Post(CepCreateDTO cep);
        Task<CepUpdateResultDTO> Put(CepUpdateDTO cep);
        Task<bool> Delete(Guid id);
    }
}
