using Domain.DTOs.Forms;
using Domain.DTOs.Shared;

namespace Domain.Interfaces.Services.Forms;

public interface IFormularioService
{
    Task<long> Create(FormularioDTO formulario);
    Task<bool> Update(FormularioDTO formulario);
    Task<bool> Delete(long id);
    Task<FormularioDTO> GetById(long id);
    Task<ResponseFilterDTO<FormularioDTO>> GetAll(FilterDTO? filter);
}
