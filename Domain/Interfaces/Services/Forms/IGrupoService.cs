using Domain.DTOs.Forms;
using Domain.DTOs.Shared;

namespace Domain.Interfaces.Services.Forms;

public interface IGrupoService
{
    Task<long> Create(GrupoDTO grupo);
    Task<bool> Update(GrupoDTO grupo);
    Task<bool> Delete(long id);
    Task<GrupoDTO> GetById(long id);
    Task<ResponseFilterDTO<GrupoDTO>> GetAll(FilterDTO? filter);
}
