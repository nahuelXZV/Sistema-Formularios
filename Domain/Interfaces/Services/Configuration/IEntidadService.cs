using Domain.DTOs.Configuration;
using Domain.DTOs.Shared;

namespace Domain.Interfaces.Services.Configuration;

public interface IEntidadService
{
    Task<long> Create(EntidadDTO entidad);
    Task<bool> Update(EntidadDTO entidad);
    Task<bool> Delete(long id);
    Task<EntidadDTO> GetById(long id);
    Task<ResponseFilterDTO<EntidadDTO>> GetAll(FilterDTO? filter);
}
