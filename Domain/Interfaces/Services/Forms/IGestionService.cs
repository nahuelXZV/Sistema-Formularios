using Domain.DTOs.Forms;
using Domain.DTOs.Shared;

namespace Domain.Interfaces.Services.Forms;

public interface IGestionService
{
    Task<long> Create(GestionDTO gestion);
    Task<bool> Update(GestionDTO gestion);
    Task<bool> Delete(long id);
    Task<GestionDTO> GetById(long id);
    Task<ResponseFilterDTO<GestionDTO>> GetAll(FilterDTO? filter);
}
