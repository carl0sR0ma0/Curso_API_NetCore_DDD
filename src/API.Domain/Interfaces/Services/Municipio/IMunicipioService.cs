using Domain.DTOs.Municipio;

namespace Domain.Interfaces.Services.Municipio
{
    public interface IMunicipioService
    {
        Task<MunicipioDTO> Get(Guid id);
        Task<MunicipioCompletoDTO> GetCompleteById(Guid id);
        Task<MunicipioCompletoDTO> GetCompleteByIBGE(int codIBGE);
        Task<IEnumerable<MunicipioCompletoDTO>> GetAll();
        Task<MunicipioCreateResultDTO> Post(MunicipioCreateDTO municipio);
        Task<MunicipioUpdateResultDTO> Put(MunicipioUpdateDTO municipio);
        Task<bool> Delete(Guid id);
    }
}
